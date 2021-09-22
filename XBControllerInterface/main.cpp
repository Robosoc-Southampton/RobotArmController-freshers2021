#include "pch.h"
#include "main.h"

int CountConnectedDevices()
{
	int connectedCount = 0;
    for (DWORD i = 0; i < XUSER_MAX_COUNT; i++)
    {
        XINPUT_STATE state = XINPUT_STATE();
        DWORD dwResult = XInputGetState(i, &state);;

        if (dwResult == ERROR_SUCCESS)
        {
            connectedCount++;
        }
    }

	return connectedCount;
}

void GetState(XINPUT_GAMEPAD* returnStruct, DWORD i)
{
    XINPUT_STATE state = XINPUT_STATE();
    DWORD dwResult = XInputGetState(i, &state);

    if (dwResult == ERROR_SUCCESS)
    {
        memcpy(returnStruct, &state.Gamepad, sizeof(XINPUT_GAMEPAD));
    }
}