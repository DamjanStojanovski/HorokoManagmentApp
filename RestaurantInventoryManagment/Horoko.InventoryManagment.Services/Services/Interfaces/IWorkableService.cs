using Horoko.InventoryManagment.Database.Models;
using Horoko.InventoryManagment.DataBase.Models;
using Horoko.InventoryManagment.DataBase.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Horoko.InventoryManagment.Services.Services.Interfaces
{
    public interface IWorkableService
    {
        DateTime GetMostSalesMadeDate(List<SalesRecord> salesTable);
        int MostProfitableWeek(List<SalesRecord> salesTable);
        int GetArticlesSoldOnSpecificDate(int articleId, DateTime date, List<SalesRecord> salesTable, List<IngredientAmount> ingredeientAmount);
        Packaging GetPackagingWhichMadeLeastProfit(List<SalesRecord> salesTable, List<IngredientInfo> ingredientInfos, List<IngredientAmount> ingredientAmounts);
        List<DetailedViewResultViewModel> GetDetailedView(List<SalesRecord> salesTable, List<IngredientInfo> ingredientInfos, List<IngredientAmount> ingredientAmounts);
    }
}
