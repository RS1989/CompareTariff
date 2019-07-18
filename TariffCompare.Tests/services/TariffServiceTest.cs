using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TarifCompare.models;
using TariffCompare.services;

namespace TariffCompare.Tests.services
{
    public class TariffServiceTest
    {
        private ITariffService _service;

        [SetUp]
        public void Setup()
        {
            _service = new TariffService();
        }

        [Test]
        [TestCase(3500, 2, 830, "Basic electricity tariff", 800, "Packaged tariff")]
        [TestCase(4500, 2, 1050, "Basic electricity tariff", 950, "Packaged tariff")]
        [TestCase(6000, 2, 1380, "Basic electricity tariff", 1400, "Packaged tariff")]
        public void GetTariff(double consumption, int expectedLength, double expectedCostValueForBasic,
            string expectedNameValueForBasic, double expectedCostValueForPack, string expectedNameValueForPack)
        {
            var result = _service.GetTariff(consumption);

            Assert.IsTrue(result.Count == expectedLength, "length is wrong");
            var basicTariff = result.FirstOrDefault(t=> t.Name.Equals("Basic electricity tariff")); 
            Assert.IsTrue(basicTariff.AnnualCost == expectedCostValueForBasic, "basic cost is wrong");
            Assert.IsTrue(basicTariff.Name == expectedNameValueForBasic, "basic name is wrong");
            var packTariff = result.FirstOrDefault(t => t.Name.Equals("Packaged tariff"));
            Assert.IsTrue(packTariff.AnnualCost == expectedCostValueForPack, "packpackageage cost is wrong");
            Assert.IsTrue(packTariff.Name == expectedNameValueForPack, "basic name is wrong");
        }
    }
}
