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
    public class ProductTests
    {
        [TestMethod()]
        public void GetFixedAnnualCost_ProductA()
        {
            ProductA productA = new ProductA();
            Assert.AreEqual(60, productA.GetFixedAnnualCost());
        }

        [TestMethod()]
        public void GetFixedAnnualCost_ProductB()
        {
            ProductB productB = new ProductB();
            Assert.AreEqual(800, productB.GetFixedAnnualCost());
        }

        [TestMethod()]
        public void GetVariableAnnualCost_ProductA_Consumption3500()
        {
            ProductA productA = new ProductA();
            decimal consumption = 3500;
            Assert.AreEqual(770M, productA.GetVariableAnnualCost(consumption));
        }

        [TestMethod()]
        public void GetVariableAnnualCost_ProductB_Consumption3500()
        {
            ProductB productB = new ProductB();
            decimal consumption = 3500;
            Assert.AreEqual(0, productB.GetVariableAnnualCost(consumption));
        }

        [TestMethod()]
        public void GetVariableAnnualCost_ProductB_Consumption4500()
        {
            ProductB productB = new ProductB();
            decimal consumption = 4500;
            Assert.AreEqual(150, productB.GetVariableAnnualCost(consumption));
        }

        [TestMethod()]
        public void GetTotalAnnualCosts_ProductA_Consumption3500()
        {
            ProductA productA = new ProductA();
            decimal consumption = 3500;
            Assert.AreEqual(830M, productA.GetTotalAnnualCosts(consumption));
        }

        [TestMethod()]
        public void GetTotalAnnualCosts_ProductB_Consumption3500()
        {
            ProductB productB = new ProductB();
            decimal consumption = 3500;
            Assert.AreEqual(800M, productB.GetTotalAnnualCosts(consumption));
        }
    }
}