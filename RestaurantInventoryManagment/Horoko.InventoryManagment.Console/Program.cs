using Horoko.InventoryManagment.Services;
using Horoko.InventoryManagment.Services.Services;
using Horoko.InventoryManagment.Services.Services.Interfaces;
using System;
using System.Linq;

namespace Horoko.InventoryManagment.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataService ds = new GetDataService();
            WorkableService ws = new WorkableService(ds);
            var date = ws.GetMostSalesMadeDate();
            var week = ws.MostProfitableWeek();
            var mostSoldVodka = ws.GetArticlesSoldOnSpecificDate(66999, new DateTime(2022, 01, 25));
            var leastPrfitPackage = ws.GetPackagingWhichMadeLeastProfit();
            var detailedView = ws.GetDetailedView();
            System.Console.WriteLine("The bottles of votka sold on 25.01.2022 is " + mostSoldVodka);
            System.Console.WriteLine($"The most sales date is {date}");
            System.Console.WriteLine($"The most sales week of the year is is {week}");
            System.Console.WriteLine($"There are {mostSoldVodka} number of bottles of votka sold");
            System.Console.WriteLine($"There packaging with least profit is{leastPrfitPackage}");
            foreach (var item in detailedView)
            {
                System.Console.WriteLine($"{item.ArticleId}  {item.Date} {item.SumOfSalePerDate}");
            }
            System.Console.ReadLine();
        }
    }
}
