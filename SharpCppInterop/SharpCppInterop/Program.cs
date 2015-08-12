using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCppInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            CppInteropTester tester = new CppInteropTester();
            tester.TransferSimpleType();
            tester.RetriveSimpleType();
            tester.RetriveArrayType();
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
