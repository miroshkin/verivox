using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox
{
    class Program
    {
        static void Main(string[] args)
        {
            TariffModel model = new TariffModel();

            //Product productA = new ProductA("basic electricity tariff");
            //Product productB = new ProductB("Packaged tariff");

            Product productA = new ProductA();
            Product productB = new ProductB();

            model.AddProduct(productA);
            model.AddProduct(productB);

            decimal consumption = 3500M;
            Console.WriteLine($"Consumption : {consumption}");

            var offers = model.GetOffers(consumption);
            foreach (var offer in offers)
            {
                Console.WriteLine($"Name : {offer.Name}, TotalCost : {offer.TotalCost}");
            }

            consumption = 4500M;
            Console.WriteLine($"Consumption : {consumption}");

            offers = model.GetOffers(consumption);
            foreach (var offer in offers)
            {
                Console.WriteLine($"Name : {offer.Name}, TotalCost : {offer.TotalCost}");
            }

            consumption = 6000M;
            Console.WriteLine($"Consumption : {consumption}");

            offers = model.GetOffers(consumption);
            foreach (var offer in offers)
            {
                Console.WriteLine($"Name : {offer.Name}, TotalCost : {offer.TotalCost}");
            }

            Console.WriteLine();
        }
    }
}
