using System.Runtime.InteropServices;

namespace PInvokeStuff
{
    class Program
    {
        static void Main()
        {
            print_line("Hello, PInvoke!");
        }

        [DllImport("NativeStuff.dll")]
        private static extern void print_line(string str);
    }
}