using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
     public class TariffModel
    {
        private List<Product> _products;

        public TariffModel()
        {
            _products = new List<Product>();
        }

        /// <summary>
        /// Adds products to product list
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            try
            {
                _products.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        /// <summary>
        /// Removes product from product list
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            try
            {
                _products.Remove((product));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Clears product list
        /// </summary>
        public void ClearProducts()
        {
            try
            {
                _products.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets offers in ascending order by total annual costs
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        public List<Offer> GetOffers(decimal consumption)
        {
            try
            {
                //Consumption value check
                if (consumption < 0)
                {
                    throw new ArgumentException("Consumption should be non-negative");
                }

                //Offers list creating
                List<Offer> offers = _products.Select(p => new Offer(p.Name, p.GetTotalAnnualCosts(consumption)))
                    .ToList();

                //In-place sorting
                offers.Sort((o1, o2) => o1.TotalCost.CompareTo(o2.TotalCost));
                return offers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
