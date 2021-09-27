#include "pch.h"
#include "main.h"

struct ControllerInput
{
    bool connected;
    bool read;
    XINPUT_STATE state;
};

bool running;
std::mutex mutex;
std::thread thread;
ControllerInput controllers[4] = {};

void Start()
{
    running = true;
    std::function<void()>controllerListener = []()
    {
        while (running)
        {
            XINPUT_STATE state = XINPUT_STATE();
            for (DWORD i = 0; i < XUSER_MAX_COUNT; i++)
            {
                if (XInputGetState(i, &state) == ERROR_SUCCESS)
                {
                    std::lock_guard<std::mutex> guard(mutex);
                    if (state.dwPacketNumber != controllers[i].state.dwPacketNumber)
                    {
                        controllers[i].connected = true;
                        controllers[i].read = true;
                        memcpy(&controllers[i].state, &state, sizeof(XINPUT_STATE));
                    }
                }
                else if (controllers[i].connected == true)
                {
                    std::lock_guard<std::mutex> guard(mutex);
                    controllers[i].connected = false;
                }
            }
        }
    };

    thread = std::thread(controllerListener);
}

void Stop()
{
    running = false;
    thread.join();
}

bool IsConnected(DWORD index)
{
    std::lock_guard<std::mutex> guard(mutex);
    return controllers[index].connected;
}

bool HasData(DWORD index)
{
    std::lock_guard<std::mutex> guard(mutex);
    return controllers[index].read;
}

void GetState(XINPUT_GAMEPAD* returnStruct, DWORD index)
{
    std::lock_guard<std::mutex> guard(mutex);
    controllers[index].read = false;
    memcpy(returnStruct, &controllers[index].state.Gamepad, sizeof(XINPUT_GAMEPAD));
}

void SetVibrate(DWORD index, WORD power)
{
    XINPUT_VIBRATION vibrateStruct =
    {
        power,
        power
    };

    XInputSetState(index, &vibrateStruct);
}