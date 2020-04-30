using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Verivox
{
    public class ProductB : Product
    {


        public ProductB()
        {
        }

        public ProductB(string name) : base(name)
        {
        }

        public override async Task<decimal> GetFixedAnnualCost()
        {
            Thread.Sleep(1000);
            return 800M;
        }

        public override async Task<decimal> GetVariableAnnualCost(decimal consumption)
        {
            Thread.Sleep(1000);

            if (consumption <= 4000M)
            {
                return 0;
            }
            return (consumption - 4000M) * .30M;
        }
    }
}
