using System;
using System.Runtime.InteropServices;

namespace NativeApi
{
    class NativeComponent
    {
        private readonly IntPtr ptr;

        public static String[] ClassNames(String library)
        {
            IntPtr ptr = NativeProxy.GetClassNames(library);
            String names = NativeProxy.Str(ptr);
            return names.Split("|");
        }

        public NativeComponent(String library, String component)
        {
            ptr = NativeProxy.GetClassObject(library, component);
        }

        ~NativeComponent()
        {
            NativeProxy.DestroyObject(ptr);
        }

        public long GetNProps()
        {
            return NativeProxy.GetNProps(ptr);
        }

        public long FindProp(String wsPropName)
        {
            return NativeProxy.FindProp(ptr, wsPropName);
        }

        public String GetPropName(long lPropNum, long lPropAlias)
        {
            string name = String.Empty;
            NativeProxy.GetPropName(ptr, lPropNum, lPropAlias, n => name = NativeProxy.Str(n));
            return name;
        }

        public bool IsPropReadable(long lPropNum)
        {
            return NativeProxy.IsPropReadable(ptr, lPropNum);
        }
        public bool IsPropWritable(long lPropNum)
        {
            return NativeProxy.IsPropWritable(ptr, lPropNum);
        }

        public long GetNMethods()
        {
            return NativeProxy.GetNMethods(ptr);
        }

        public long FindMethod(string wsMethodName)
        {
            return NativeProxy.FindMethod(ptr, wsMethodName);
        }

        public String GetMethodName(long lMethodNum, long lMethodAlias)
        {
            string name = String.Empty;
            NativeProxy.GetMethodName(ptr, lMethodNum, lMethodAlias, n => name = NativeProxy.Str(n));
            return name;
        }

        public long GetNParams(long lMethodNum)
        {
            return NativeProxy.GetNParams(ptr, lMethodNum);
        }

        public bool HasRetVal(long lMethodNum)
        {
            return NativeProxy.HasRetVal(ptr, lMethodNum);
        }
    }

}