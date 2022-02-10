using System;

namespace Horoko.InventoryManagment.Services
{
    public class MostSalesViewModel
    {
        public MostSalesViewModel(int amount, decimal price, decimal totalSale, DateTime date)
        {
            this.Amount = amount;
            this.Price = price;
            this.TotalSale = totalSale;
            this.Date = date;
        }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalSale { get; set; }
        public DateTime Date { get; set; }
    }
}
