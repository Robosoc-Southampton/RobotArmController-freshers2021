using System.Runtime.InteropServices;

namespace XBControllerViewer
{
    static class XBControllerInterface
    {
        [DllImport(@"XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);
    }
}
