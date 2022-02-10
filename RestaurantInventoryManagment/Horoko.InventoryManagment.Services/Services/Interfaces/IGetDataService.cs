using Horoko.InventoryManagment.Database.Models;
using Horoko.InventoryManagment.DataBase.Models;
using System.Collections.Generic;

namespace Horoko.InventoryManagment.Services.Services.Interfaces
{
    public interface IGetDataService
    {
        IEnumerable<IngredientInfo> GetIngredientInfoData(string filePath);
        IEnumerable<IngredientAmount> GetIngredientAmountData(string filePath);
        IEnumerable<SalesRecord> GetSalesRecordData(string filePath);
    }
}
