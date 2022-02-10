using System;

namespace Horoko.InventoryManagment.Services
{
    public class DetailedViewResultViewModel
    {
        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public decimal SumOfSalePerDate { get; set; }
    }
}
