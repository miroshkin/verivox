using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verivox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verivox.Tests
{
    [TestClass()]
    public class TariffModelTests
    {
        public const string productA_Name = "basic electricity tariff";
        public const string productB_Name = "Packaged tariff";

        private TariffModel InitializeTariffModel()
        {
            TariffModel model = new TariffModel();
            ProductA productA = new ProductA(productA_Name);
            ProductB productB = new ProductB(productB_Name);
            model.AddProduct(productA);
            model.AddProduct(productB);
            return model;
        }

        [TestMethod()]
        public void GetOffers_ThrowsArgumentException_IfConsumptionIsLowerThanZero()
        {
            decimal consumption = -100;
            TariffModel model = new TariffModel();
            var ex = Assert.ThrowsException<ArgumentException>(() => model.GetOffers(consumption));
            Assert.AreEqual("Consumption should be non-negative", ex.Message);
        }

        [TestMethod()]
        public void GetOffers_ProductBIsTheBestOffer_IfConsumptionIs3500()
        {
            decimal consumption = 3500;
            var model = InitializeTariffModel();
            var offers = model.GetOffers(consumption);

            var bestOffer = offers[0];
            Assert.AreEqual(productB_Name, bestOffer.Name);
        }

        [TestMethod()]
        public void GetOffers_ProductBIsTheBestOffer_IfConsumptionIs4500()
        {
            decimal consumption = 4500;
            var model = InitializeTariffModel();
            var offers = model.GetOffers(consumption);

            var bestOffer = offers[0];
            Assert.AreEqual(productB_Name, bestOffer.Name);
        }

        [TestMethod()]
        public void GetOffers_ProductAIsTheBestOffer_IfConsumptionIs6000()
        {
            decimal consumption = 6000;
            var model = InitializeTariffModel();
            var offers = model.GetOffers(consumption);
            var bestOffer = offers[0];
            Assert.AreEqual(productA_Name, bestOffer.Name);
        }

 
    }
}