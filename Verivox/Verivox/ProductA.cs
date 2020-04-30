using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Verivox
{
    public class ProductA : Product
    {
        public ProductA()
        {
        }

        public ProductA (string name) : base(name)
        {
        }


        public override async Task<decimal> GetFixedAnnualCost()
        {
            decimal costPerMonth = 5M;
            ushort monthCount = 12;

            Thread.Sleep(1000);

            return costPerMonth * monthCount;
        }

        public override async Task<decimal> GetVariableAnnualCost(decimal consumption)
        {
            Thread.Sleep(1000);

            return consumption * .22M;
        }
    }
}
