using Horoko.InventoryManagment.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horoko.InventoryManagment.Services
{
    public class IngredientAmountAndSalesRecordJoined
    {
        public IngredientAmountAndSalesRecordJoined(long articleId, long id, DateTime date, int amount, decimal price)
        {
            this.ArticleId = articleId;
            this.Id = id;
            this.DateAndTimeOfOrder = date;
            this.Amount = amount;
            this.Price = price;
        }
        public long ArticleId { get; set; }
        public long Id { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
