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
            WorkableService ws = new WorkableService();
            //var date = ws.GetMostSalesMadeDate();
            //var date2 = ws.MostProfitableWeek();
            //var mostSoldVodka = ws.GetArticlesSoldOnSpecificDate(66999, new DateTime(2022, 01, 25));
            //System.Console.WriteLine("The bottles of votka sold on 25.01.2022 is " + mostSoldVodka);
            //System.Console.WriteLine(date);
            //System.Console.WriteLine(date2);
            var ex = ws.GetPackagingWhichMadeLeastProfit();
            System.Console.WriteLine(ex);
            System.Console.ReadLine();
        }
    }
}
