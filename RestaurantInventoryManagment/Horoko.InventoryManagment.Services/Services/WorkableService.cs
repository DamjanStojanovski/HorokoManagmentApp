using Horoko.InventoryManagment.DataBase.Models.Enums;
using Horoko.InventoryManagment.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Horoko.InventoryManagment.Services.Services
{
    public class WorkableService : IWorkableService
    {
        public int GetArticlesSoldOnSpecificDate(int articleId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<IngredientAmountAndSalesRecordJoined> GetDetailedView()
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
            throw new NotImplementedException();
        }

        public int MostProfitableWeek()
        {
            GetDataService ds = new GetDataService();
            var salesRecords = ds.GetSalesRecordData(Config.SalesRecordsFilePath);
            return 0;

            //return salesRecords.GroupBy(x => x.DateAndTimeOfOrder.Date, (date, listOfItems) =>
            //{
            //    var maxSale = listOfItems.Sum(i => i.Price * i.Amount);
            //    return new { date, maxSale };
            //}).OrderByDescending(x => x.maxSale).First().date;
        }
    }
}
