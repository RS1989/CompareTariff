using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffCompare.services;

namespace TarifCompare.models
{
    public class Tariff
    {
        public Tariff(Calculator calculator)
        {
            this._calculator = calculator;
        }

        public string Name { get; set; }
        public double AnnualCost { get; set; }

        private Calculator _calculator;

        public void Calculate(double consumption)
        {
            _calculator.Calculate(this, consumption);
        }
    }
}
