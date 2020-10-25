using System;
using System.Runtime.InteropServices;

namespace dotNetLoader
{
    class NativeApiProxy
    {
        [DllImport("NativeApiProxy.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetClassNames(string lib);

        [DllImport("NativeApiProxy.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetClassObject(string lib, string name);

        [DllImport("NativeApiProxy.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr DestroyObject(IntPtr ptr);

        static void Main(string[] args)
        {
            IntPtr pNames = GetClassNames(args[0]);
            String classNames = Marshal.PtrToStringUni(pNames);
            foreach (String name in classNames.Split("|"))
            {
                IntPtr ptr = GetClassObject(args[0], name);
                Console.WriteLine($" - {name}");
                DestroyObject(ptr);
            }
        }
    }
}
