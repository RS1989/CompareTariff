using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarifCompare.models;

namespace TariffCompare.services
{
    public class PackageCalculator:Calculator
    {
        private readonly int _upTo;
        private readonly int _upToCost;
        private readonly double _consumptionCost;
        private readonly string _tariffName;
        

        public PackageCalculator()
        {
            _upTo = 4000;
            _upToCost = 800;
            _consumptionCost = 0.3;
            _tariffName = "Packaged tariff";
        }

        public override void Calculate(Tariff tariff, double consumption)
        {
            tariff.Name = _tariffName;

            if (consumption <= _upTo)
            {
                tariff.AnnualCost = _upToCost;
            }
            else
            {
                var additionalConsumption = consumption - _upTo;
                var additionalCost = additionalConsumption * _consumptionCost;
                var total = additionalCost + _upToCost;
                tariff.AnnualCost = total;
            }
        }
    }
}
