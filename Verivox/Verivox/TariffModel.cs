using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
     public class TariffModel
    {
        private ObservableCollection<Product> _products;

        public TariffModel()
        {

            _products = new ObservableCollection<Product>();
            _products.CollectionChanged += ProductsCollectionChanged;
        }

        private void ProductsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // They removed something. 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Product p in e.OldItems)
                {
                    Console.WriteLine(p.Name.ToString());
                }
                Console.WriteLine();
            }

            // They added something. 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Product p in e.NewItems)
                {
                    Console.WriteLine(p.Name.ToString());
                }
            }
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
                List<Offer> offers = _products.AsParallel().Select(p => new Offer(p.Name, p.GetTotalAnnualCosts(consumption).Result))
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
