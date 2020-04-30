using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
    class Test : ITest
    {
        void ITest.Execute()
        {
            Console.WriteLine("Test works!");
        }
    }
}
