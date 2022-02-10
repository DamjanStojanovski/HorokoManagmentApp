using System;

namespace Horoko.InventoryManagment.Database.Models
{
    public class SalesRecord
    {
        public long IngredientPortionId { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
