using System;

namespace NativeApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            String library = args[0];
            String[] names = NativeComponent.ClassNames(library);
            foreach (String name in names)
            {
                Console.WriteLine($"{name}");
                NativeComponent component = new NativeComponent(library, name);
                Console.WriteLine($" - Свойства");
                long props = component.GetNProps();
                for (long i = 0; i < props; i++)
                {
                    String en = component.GetPropName(i, 0);
                    String ru = component.GetPropName(i, 1);
                    String rw = component.IsPropWritable(i) ? "RW" : "RO";
                    Console.WriteLine($"   - {ru} / {en} - {rw}");
                }
                Console.WriteLine($" - Методы");
                long methods = component.GetNMethods();
                for (long i = 0; i < methods; i++)
                {
                    String en = component.GetMethodName(i, 0);
                    String ru = component.GetMethodName(i, 1);
                    String rw = component.HasRetVal(i) ? "func" : "proc";
                    long par = component.GetNParams(i);
                    Console.WriteLine($"   - {ru} / {en} - {rw} - {par}");
                }
                Console.WriteLine();
            }
        }
    }
}
