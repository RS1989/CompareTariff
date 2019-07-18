using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarifCompare.models;

namespace TariffCompare.services
{
    public class TariffService:ITariffService
    {
        private readonly List<Tariff> _tariffList; 

        public TariffService()
        {
            _tariffList = new List<Tariff>();
        }

        public List<Tariff> GetTariff(double consumption)
        {
            Tariff tariff;
            tariff = new Tariff(new BasicCalculator());
            tariff.Calculate(consumption);
            _tariffList.Add(tariff);

            tariff = new Tariff(new PackageCalculator());
            tariff.Calculate(consumption);
            _tariffList.Add(tariff);

            return _tariffList.OrderBy(t=> t.AnnualCost).ToList();
        }
    }
}
