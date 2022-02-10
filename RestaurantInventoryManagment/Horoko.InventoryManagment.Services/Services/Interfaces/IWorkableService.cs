using Horoko.InventoryManagment.DataBase.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Horoko.InventoryManagment.Services.Services.Interfaces
{
    public interface IWorkableService
    {
        DateTime GetMostSalesMadeDate();
        int MostProfitableWeek();
        int GetArticlesSoldOnSpecificDate(int articleId, DateTime date);
        Packaging GetPackagingWhichMadeLeastProfit();
        List<DetailedViewResultViewModel> GetDetailedView();
    }
}
