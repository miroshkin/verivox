using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override decimal GetFixedAnnualCost()
        {
            decimal costPerMonth = 5M;
            ushort monthCount = 12;

            return costPerMonth * monthCount;
        }

        public override decimal GetVariableAnnualCost(decimal consumption)
        {
            return consumption * .22M;
        }
    }
}
