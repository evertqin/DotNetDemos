using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpCppInterop
{
    class CppInteropTester
    {
        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_simple_type(int num);

        public void TransferSimpleType()
        {
            int num = 5;
            get_simple_type(num);
        }

        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double return_simple_type(double num);

        public void RetriveSimpleType()
        {
            double num = 5.0;
            double ret = return_simple_type(num);
            Console.WriteLine(string.Format("From RetriveSimpleType we get: \"{0}\"", ret));
        }


        struct OneDimRetArray
        {
            public IntPtr content;
            public int size;
        };

        [DllImport("CppLib.dll")]
        public static extern IntPtr make_1d_array(double[] nums, int size);
        [DllImport("CppLib.dll")]
        public static extern int release_one_dim(IntPtr toFree);

        public void RetriveArrayType()
        {
            Console.WriteLine("Retriving Array");
            double[] nums = { 1, 2, 3, 4, 5 };
            IntPtr ptr = make_1d_array(nums, nums.Length);
            OneDimRetArray result = (OneDimRetArray)Marshal.PtrToStructure(ptr, typeof(OneDimRetArray));

            double[] num = new double[result.size];
            Marshal.Copy(result.content, num, 0, result.size);
            foreach (double d in num)
            {
                Console.Write(d + ", ");
            }
            Console.WriteLine();

        }


    }
}
