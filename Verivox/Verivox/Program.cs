using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Verivox
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ITest, Test>();
            ITest test = container.Resolve<ITest>();
            test.Execute();

            TariffModel model = new TariffModel();

            //Product productA = new ProductA("basic electricity tariff");
            //Product productB = new ProductB("Packaged tariff");

            Product productA = new ProductA();
            Product productB = new ProductB();

            


            for (int i = 0; i < 4; i++)
            {
                model.AddProduct(productA);
                model.AddProduct(productB);
            }

            decimal consumption;
            Stopwatch sw;
            List<Offer> offers;
            
            Calculate(model, 3500M);
            Calculate(model, 4500M);
            Calculate(model, 6000M);

            Console.WriteLine($"Number of cores - {Environment.ProcessorCount}");
        }

        private static void Calculate(TariffModel model, decimal consumption)
        {
            Console.WriteLine($"Consumption : {consumption}");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Offer> offers = model.GetOffers(consumption);
            sw.Stop();
            Console.WriteLine($"Elapsed milliseconds: {sw.ElapsedMilliseconds}");

            foreach (var offer in offers)
            {
                 Console.WriteLine($"Name : {offer.Name}, TotalCost : {offer.TotalCost}");
            }
            Console.WriteLine();
        }
    }
}
