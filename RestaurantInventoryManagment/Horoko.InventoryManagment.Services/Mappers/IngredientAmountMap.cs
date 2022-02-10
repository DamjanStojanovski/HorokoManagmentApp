using CsvHelper.Configuration;
using Horoko.InventoryManagment.DataBase.Models;
using System.Globalization;

namespace Horoko.InventoryManagment.Services.Mappers
{
    public sealed class IngredientAmountMap : ClassMap<IngredientAmount>
    {
        public IngredientAmountMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.ArticleId).Name("ArticleId");
            Map(x => x.Id).Name("Id");
            Map(x => x.UnitPerSaleMark).Name("UnitPerSale");
            Map(x => x.AmountPerSale).Name("AmountPerSale");
        }
    }
}
