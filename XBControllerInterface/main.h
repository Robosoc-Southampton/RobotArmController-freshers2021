#pragma once
#include "core.h"

extern "C"
{
	API void Start();
	API void Stop();
	API bool IsConnected(DWORD);
	API bool HasData(DWORD);
	API void GetState(XINPUT_GAMEPAD* gamepad, DWORD i);
	API void SetVibrate(DWORD, WORD);
}