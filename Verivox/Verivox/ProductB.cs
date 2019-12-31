using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override decimal GetFixedAnnualCost()
        {
            return 800M;
        }

        public override decimal GetVariableAnnualCost(decimal consumption)
        {
            if (consumption <= 4000M)
            {
                return 0;
            }
            return (consumption - 4000M) * .30M;
        }
    }
}
