using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
    public class Offer
    {
        /// <summary>
        /// Offer name 
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Total annual cost for client
        /// </summary>
        public decimal TotalCost
        {
            get { return _totalCost; }
        }

        private string _name;
        private decimal _totalCost;

        public Offer(string name, decimal totalCost)
        {
            this._name = name;
            this._totalCost = totalCost;
        }


    }
}
