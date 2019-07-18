using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarifCompare.models;

namespace TariffCompare.services
{
    public class BasicCalculator : Calculator
    {
        private readonly double _consumptionCost;
        private readonly string _tariffName;
        private readonly int _baseCostPerMaount;
        private readonly int _mounthCount;

        public BasicCalculator()
        {
            _consumptionCost = 0.22;
            _tariffName = "Basic electricity tariff";
            _baseCostPerMaount = 5;
            _mounthCount = 12;
        }

        public override void Calculate(Tariff tariff, double consumption)
        {
            tariff.Name = _tariffName;

            var baseSum = _baseCostPerMaount * _mounthCount;
            var consumptionSum = _consumptionCost * consumption;
            var total = baseSum + consumptionSum;

            tariff.AnnualCost = total;
        }
    }
}
