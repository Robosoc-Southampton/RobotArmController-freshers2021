using System.Runtime.InteropServices;

namespace XBControllerViewer
{
    static class XBControllerInterface
    {
        [DllImport(@"C:\Dev\RobotController\XBControllerInterface\bin\Debug-Win32\XBControllerInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);
    }
}
