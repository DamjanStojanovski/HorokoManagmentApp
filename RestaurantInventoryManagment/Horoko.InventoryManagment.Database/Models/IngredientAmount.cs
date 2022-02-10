using Horoko.InventoryManagment.Database.Models.Enums;

namespace Horoko.InventoryManagment.DataBase.Models
{
    public class IngredientAmount
    {
        public long ArticleId { get; set; }
        public long Id { get; set; }
        public UnitPerSale UnitPerSaleMark { get; set; }
        public int AmountPerSale { get; set; }
    }
}
