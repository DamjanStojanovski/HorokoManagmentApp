using Horoko.InventoryManagment.Database.Models.Enums;
using Horoko.InventoryManagment.DataBase.Models.Enums;
using System;

namespace Horoko.InventoryManagment.Services.Services
{
    public class InfoAmountAndSalesViewModel
    {
        public InfoAmountAndSalesViewModel(long articleId, string articleDescription, Packaging packaging, decimal pricePerUnit, string group, long id, UnitPerSale unitPerSale, int amountPerSale, DateTime date, int amount, decimal price)
        {
            this.ArticleId = articleId;
            this.ArticleDescription = articleDescription;
            this.Packaging = packaging;
            this.Priceperunit = pricePerUnit;
            this.Group = group;
            this.Id = id;
            this.UnitPerSale = unitPerSale;
            this.AmountPerSale = amountPerSale;
            this.DateAndTimeOfOrder = date;
            this.Amount = amount;
            this.Price = price;
        }
        public long ArticleId { get; set; }
        public string ArticleDescription { get; set; }
        public Packaging Packaging { get; set; }
        public decimal Priceperunit { get; set; }
        public string Group { get; set; }
        public long Id { get; set; }
        public UnitPerSale UnitPerSale { get; set; }
        public int AmountPerSale { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
