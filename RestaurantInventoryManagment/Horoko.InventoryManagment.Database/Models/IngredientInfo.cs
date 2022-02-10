using Horoko.InventoryManagment.DataBase.Models.Enums;

namespace Horoko.InventoryManagment.DataBase.Models
{
    public class IngredientInfo
    {
        public long ArticleNumber { get; set; }
        public string ArticleDescription { get; set; }
        public decimal Priceperunit { get; set; }
        public Packaging Packaging { get; set; }
        public string Group { get; set; }
    }
}
