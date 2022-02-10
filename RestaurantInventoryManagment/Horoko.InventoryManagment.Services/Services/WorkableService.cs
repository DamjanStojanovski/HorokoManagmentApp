using Horoko.InventoryManagment.Database.Models;
using Horoko.InventoryManagment.DataBase.Models.Enums;
using Horoko.InventoryManagment.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Horoko.InventoryManagment.Services.Services
{
    public class WorkableService : IWorkableService
    {
        public int GetArticlesSoldOnSpecificDate(int articleId, DateTime date)
        {
            GetDataService ds = new GetDataService();
            var productAmountRecords = ds.GetIngredientAmountData(Config.IngredientAmoutFilePath);
            var salesRecords = ds.GetSalesRecordData(Config.SalesRecordsFilePath);

            var productAmountAndSalesJoined = productAmountRecords
                .Join
                (
                salesRecords,
                prodAmount => prodAmount.Id,
                sales => sales.IngredientPortionId,
                (prodAmountTab, salesTab) => new IngredientAmountAndSalesViewModel(prodAmountTab.ArticleId, prodAmountTab.Id, salesTab.DateAndTimeOfOrder.Date,salesTab.Amount, salesTab.Price)
                );

            return productAmountAndSalesJoined.Where(x => x.ArticleId == articleId && x.DateAndTimeOfOrder == date).Count();
        }

        public List<IngredientAmountAndSalesViewModel> GetDetailedView()
        {
            throw new NotImplementedException();
        }

        public DateTime GetMostSalesMadeDate()
        {
            GetDataService ds = new GetDataService();
            var salesRecords = ds.GetSalesRecordData(Config.SalesRecordsFilePath);

            return salesRecords.GroupBy(x => x.DateAndTimeOfOrder.Date, (date, listOfItems) =>
            {
                var maxSale = listOfItems.Sum(i => i.Price * i.Amount);
                return new { date, maxSale };
            }).OrderByDescending(x => x.maxSale).First().date;
        }

        public Packaging GetPackagingWhichMadeLeastProfit()
        {
            GetDataService ds = new GetDataService();
            var productInfoRecords = ds.GetIngredientInfoData(Config.IngredientInfoFilePath);
            var productAmountRecords = ds.GetIngredientAmountData(Config.IngredientAmoutFilePath);
            var salesRecords = ds.GetSalesRecordData(Config.SalesRecordsFilePath);

            var tablesJoined = productInfoRecords.Join
                (
                    productAmountRecords,
                    infoTab => infoTab.ArticleNumber,
                    amountTab => amountTab.ArticleId,
                    (infoTab, amountTab) =>
                    new InfoAmountViewModel(infoTab.ArticleNumber, infoTab.ArticleDescription, infoTab.Packaging, infoTab.Priceperunit, infoTab.Group, amountTab.Id, amountTab.UnitPerSaleMark, amountTab.AmountPerSale)
                )
                .Join
                (
                   salesRecords,
                   infoAndAmount => infoAndAmount.Id,
                   sales => sales.IngredientPortionId,
                   (infoAmount, sales) => new InfoAmountAndSalesViewModel(infoAmount.ArticleId, infoAmount.ArticleDescription, infoAmount.Packaging, infoAmount.Priceperunit, infoAmount.Group, infoAmount.Id, infoAmount.UnitPerSale, infoAmount.AmountPerSale, sales.DateAndTimeOfOrder.Date, sales.Amount, sales.Price)
                );

            return tablesJoined.OrderBy(x => (x.Amount * x.Price)).First().Packaging;

        }

        public int MostProfitableWeek()
        {
            GetDataService ds = new GetDataService();
            var salesRecords = ds.GetSalesRecordData(Config.SalesRecordsFilePath);

            var groupsByWeek = salesRecords.GroupBy(i => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                    i.DateAndTimeOfOrder.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday));

            Dictionary<int, decimal> data = new Dictionary<int, decimal>();

            decimal maxSales = 0;
            foreach (var item in groupsByWeek)
            {
                for (int i = 0; i < item.Count(); i++)
                {
                    maxSales += (item.ElementAt(i).Amount * item.ElementAt(i).Price);
                }
                data.Add(item.Key, maxSales);
            };

            return data.OrderByDescending(x => x.Value).First().Key;
        }
    }
}
