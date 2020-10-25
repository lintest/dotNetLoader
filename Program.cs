using System;
using System.Runtime.InteropServices;

namespace dotAddIn
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lib);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void FreeLibrary(IntPtr module);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr module, string proc);

        private delegate IntPtr GetClassNames();
        private delegate long GetClassObject(String name, ref Object ptr);

        static void Main(string[] args)
        {
            Console.WriteLine($"Load library: {args[0]}");
            IntPtr module = LoadLibrary(args[0]);
            if (module == IntPtr.Zero)
            {
                Console.WriteLine($"Could not load library: {Marshal.GetLastWin32Error()}");
                return;
            }
            IntPtr methGetClassNames = GetProcAddress(module, "GetClassNames");
            if (methGetClassNames == IntPtr.Zero)
            {
                Console.WriteLine($"Could not load method: {Marshal.GetLastWin32Error()}");
                FreeLibrary(module);
                return;
            }
            GetClassNames getClassNames = (GetClassNames)Marshal.GetDelegateForFunctionPointer(methGetClassNames, typeof(GetClassNames));
            IntPtr methGetClassObject = GetProcAddress(module, "GetClassObject");
            if (methGetClassObject == IntPtr.Zero)
            {
                Console.WriteLine($"Could not load method: {Marshal.GetLastWin32Error()}");
                FreeLibrary(module);
                return;
            }
            GetClassObject getClassObject = (GetClassObject)Marshal.GetDelegateForFunctionPointer(methGetClassObject, typeof(GetClassObject));
            String classNames = Marshal.PtrToStringUni(getClassNames());
            foreach (String name in classNames.Split("|"))
            {
                Console.WriteLine($" - {name}");
            }
        }
    }
}
