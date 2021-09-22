using System.Runtime.InteropServices;

namespace XBControllerViewer
{
    unsafe static class XBControllerInterface
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
        public static extern int CountConnectedDevices();

        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetState(XBControllerState* state, int index);

        public static XBControllerState GetState(int index)
        {
            XBControllerState state = new XBControllerState();

            GetState(&state, index);

            return state;
        }
    }
}
