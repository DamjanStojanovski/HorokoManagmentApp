using CsvHelper.Configuration;
using Horoko.InventoryManagment.Database.Models;
using System.Globalization;

namespace Horoko.InventoryManagment.Services.Mappers
{
    public sealed class SalesRecordMap : ClassMap<SalesRecord>
    {
        public SalesRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.IngredientPortionId).Name("IngredientPortioningId");
            Map(x => x.DateAndTimeOfOrder).Name("Date");
            Map(x => x.Amount).Name("Amount");
            Map(x => x.Price).Name("Price");
        }
    }
}
