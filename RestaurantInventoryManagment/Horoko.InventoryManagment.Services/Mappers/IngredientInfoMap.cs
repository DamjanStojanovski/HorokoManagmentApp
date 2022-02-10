using CsvHelper.Configuration;
using Horoko.InventoryManagment.DataBase.Models;
using Horoko.InventoryManagment.DataBase.Models.Enums;
using System.Globalization;

namespace Horoko.InventoryManagment.Services
{
    public sealed class IngredientInfoMap : ClassMap<IngredientInfo>
    {
        public IngredientInfoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.ArticleNumber).Name("ArticleNumber");
            Map(x => x.ArticleDescription).Name("ArticleDescription");
            Map(x => x.Priceperunit).Name("Price per unit");
            Map(x => x.Packaging).TypeConverter<MyEnumConverter<Packaging>>();
            Map(x => x.Group).Name("Group");
        }
    }
}
