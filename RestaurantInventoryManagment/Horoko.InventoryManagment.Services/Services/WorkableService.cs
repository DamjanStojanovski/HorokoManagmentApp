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
        private GetDataService _dataservice;
        public WorkableService(GetDataService dataService)
        {
            _dataservice = dataService;
        }
        public int GetArticlesSoldOnSpecificDate(int articleId, DateTime date)
        {
            var productAmountRecords = _dataservice.GetIngredientAmountData(Config.IngredientAmoutFilePath);
            var salesRecords = _dataservice.GetSalesRecordData(Config.SalesRecordsFilePath);

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

        public List<DetailedViewResultViewModel> GetDetailedView()
        {
            var productInfoRecords = _dataservice.GetIngredientInfoData(Config.IngredientInfoFilePath);
            var productAmountRecords = _dataservice.GetIngredientAmountData(Config.IngredientAmoutFilePath);
            var salesRecords = _dataservice.GetSalesRecordData(Config.SalesRecordsFilePath);
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

            var ex = tablesJoined.GroupBy(x => new
            {
                x.DateAndTimeOfOrder,
                x.Id
            });

            List<DetailedViewResultViewModel> result = new List<DetailedViewResultViewModel>();
            decimal sumOfSales = 0;
            foreach (var item in ex)
            {
                DetailedViewResultViewModel model = new DetailedViewResultViewModel();
                for (int i = 0; i < item.Count(); i++)
                {
                    sumOfSales += (item.ElementAt(i).Amount * item.ElementAt(i).Price);
                }
                model.ArticleId = item.Key.Id;
                model.Date = item.Key.DateAndTimeOfOrder;
                model.SumOfSalePerDate = sumOfSales;
                result.Add(model);
            }

            return result;
        }

        public DateTime GetMostSalesMadeDate()
        {
            var salesRecords = _dataservice.GetSalesRecordData(Config.SalesRecordsFilePath);

            return salesRecords.GroupBy(x => x.DateAndTimeOfOrder.Date, (date, listOfItems) =>
            {
                var maxSale = listOfItems.Sum(i => i.Price * i.Amount);
                return new { date, maxSale };
            }).OrderByDescending(x => x.maxSale).First().date;
        }

        public Packaging GetPackagingWhichMadeLeastProfit()
        {
            var productInfoRecords = _dataservice.GetIngredientInfoData(Config.IngredientInfoFilePath);
            var productAmountRecords = _dataservice.GetIngredientAmountData(Config.IngredientAmoutFilePath);
            var salesRecords = _dataservice.GetSalesRecordData(Config.SalesRecordsFilePath);

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
            var salesRecords = _dataservice.GetSalesRecordData(Config.SalesRecordsFilePath);

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
