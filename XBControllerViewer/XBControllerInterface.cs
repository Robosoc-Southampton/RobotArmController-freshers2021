using System.Diagnostics;
using System.Runtime.InteropServices;

namespace XBControllerViewer
{
    internal static unsafe class XBControllerInterface
    {
        public struct XBControllerState
        {
            public ushort buttons;
            public byte leftTrigger, rightTrigger;
            public short thumbLX, thumbLY, thumbRX, thumbRY;

            public override string ToString()
            {
                return $"Left: [{thumbLX}, {thumbLY}]\nRight: [{thumbRX}, {thumbRY}]";
            }
        }


        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Start();
        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Stop();
        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsConnected(uint index);

        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasData(uint index);

        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetState(XBControllerState* state, uint index);

        public static XBControllerState GetState(uint index)
        {
            XBControllerState state = new XBControllerState();

            GetState(&state, index);

            return state;
        }

        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVibrate(uint index, ushort power);
    }
}
