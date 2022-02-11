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
            System.Console.WriteLine("Getting Data");
            System.Console.WriteLine("------------------");
            GetDataService ds = new GetDataService();
            var ingredientInfoData = ds.GetIngredientInfoData(Config.IngredientInfoFilePath).ToList();
            var ingredientAmountData = ds.GetIngredientAmountData(Config.IngredientAmoutFilePath).ToList();
            var salesData = ds.GetSalesRecordData(Config.SalesRecordsFilePath).ToList();
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine("Data collected");
            System.Console.Clear();
            System.Console.WriteLine("Please choose what you want to want to find out");
            System.Console.WriteLine("1. Get on which date the restaurant made the most sales");
            System.Console.WriteLine("2. Get the most profitable week for the restaurant");
            System.Console.WriteLine("3. Get how many bottles of votka were sold on 25.01.2022");
            System.Console.WriteLine("4. Get which packaging made the least prfit");
            System.Console.WriteLine("5. Get detailed view of sales per article id per day and summed sales of that day");
            WorkableService ws = new WorkableService();
            string userChoice = System.Console.ReadLine();
            dynamic result;
            switch (userChoice)
            {
                case "1":
                    result = ws.GetMostSalesMadeDate(salesData);
                    System.Console.WriteLine($"The most sales date is {result}");
                    break;
                case "2":
                    result = ws.MostProfitableWeek(salesData);
                    System.Console.WriteLine($"The most profitable week is {result}");
                    break;
                case "3":
                    result = ws.GetArticlesSoldOnSpecificDate(66999, new DateTime(2022, 01, 25), salesData, ingredientAmountData);
                    System.Console.WriteLine("The bottles of votka sold on 25.01.2022 is " + result);
                    break;
                case "4":
                    result = ws.GetPackagingWhichMadeLeastProfit(salesData, ingredientInfoData, ingredientAmountData);
                    System.Console.WriteLine($"There packaging with least profit is{result}");
                    break;
                case "5":
                    result = ws.GetDetailedView(salesData, ingredientInfoData, ingredientAmountData);
                    foreach (var item in result)
                    {
                        System.Console.WriteLine($"{item.ArticleId}  {item.Date} {item.SumOfSalePerDate }");
                    }
                    break;
                default:
                    System.Console.WriteLine("Sorry you must enter from 1 to 5. Exiting...");
                    break;
            }
            System.Console.ReadLine();
        }
    }
}
