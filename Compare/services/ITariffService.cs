using System.Collections.Generic;
using TarifCompare.models;

namespace TariffCompare.services
{
    public interface ITariffService
    {
        List<Tariff> GetTariff(double consumption);
    }
}