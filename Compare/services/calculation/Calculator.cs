using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarifCompare.models;

namespace TariffCompare.services
{
    public abstract class Calculator
    {
        public abstract void Calculate(Tariff product, double consumption);
    }
}
