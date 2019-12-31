using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
    public abstract class Product
    {
        public Product()
        {
            _name = GetType().Name;
        }

        public Product(string name)
        {
            _name = name;
        }

        protected string _name;

        public string Name => _name;

        public abstract decimal GetFixedAnnualCost();

        public abstract decimal GetVariableAnnualCost(decimal consumption);

        public decimal GetTotalAnnualCosts(decimal consumption)
        {
            return GetFixedAnnualCost() + GetVariableAnnualCost(consumption);
        }

    }
}
