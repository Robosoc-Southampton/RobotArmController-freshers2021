#pragma once
#include "core.h"

extern "C"
{
	API int CountConnectedDevices();
	API void GetState(XINPUT_GAMEPAD* gamepad, DWORD i);
}