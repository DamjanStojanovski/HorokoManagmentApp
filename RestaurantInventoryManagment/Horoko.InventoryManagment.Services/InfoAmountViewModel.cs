using Horoko.InventoryManagment.Database.Models.Enums;
using Horoko.InventoryManagment.DataBase.Models.Enums;

namespace Horoko.InventoryManagment.Services
{
    public class InfoAmountViewModel
    {
        public InfoAmountViewModel(long articleId, string articleDescription, Packaging packaging, decimal priceperunit, string group, long id, UnitPerSale unitPerSale, int amountPerSale)
        {
            this.ArticleId = articleId;
            this.ArticleDescription = articleDescription;
            this.Packaging = packaging;
            this.Priceperunit = priceperunit;
            this.Group = group;
            this.Id = id;
            this.UnitPerSale = unitPerSale;
            this.AmountPerSale = amountPerSale;
        }
        public long ArticleId { get; set; }
        public string ArticleDescription { get; set; }
        public Packaging Packaging { get; set; }
        public decimal Priceperunit { get; set; }
        public string Group { get; set; }
        public long Id { get; set; }
        public UnitPerSale UnitPerSale { get; set; }
        public int AmountPerSale { get; set; }
    }
}
