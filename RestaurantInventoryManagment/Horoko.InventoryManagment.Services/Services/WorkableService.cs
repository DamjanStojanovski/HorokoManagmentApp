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
