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

        public abstract Task<decimal> GetFixedAnnualCost();

        public abstract Task<decimal> GetVariableAnnualCost(decimal consumption);

        public async Task<decimal> GetTotalAnnualCosts(decimal consumption)
        {
            decimal fixedPart = await GetFixedAnnualCost();
            decimal variablePart = await GetVariableAnnualCost(consumption);

            return  fixedPart + variablePart;
        }

    }
}
