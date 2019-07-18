using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TarifCompare.models;
using TariffCompare.services;

namespace TariffCompare.Tests.services.calculation
{
    public class PackageCalculatorTest
    {
        [Test]
        [TestCase(3500, 800, "Packaged tariff")]
        [TestCase(4500, 950, "Packaged tariff")]
        [TestCase(6000, 1400, "Packaged tariff")]
        public void Calculate(double consumption, double expectedCostValue, string expectedNameValue)
        {
            Tariff tariff;
            tariff = new Tariff(new PackageCalculator());
            tariff.Calculate(consumption);            

            Assert.IsTrue(tariff.Name.Equals(expectedNameValue), $"return wrong name value");
            Assert.IsTrue(tariff.AnnualCost == expectedCostValue, $"return wrong cost value");
        }
    }
}
