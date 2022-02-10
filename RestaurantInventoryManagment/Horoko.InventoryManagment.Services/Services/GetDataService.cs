using CsvHelper;
using Horoko.InventoryManagment.Database.Models;
using Horoko.InventoryManagment.DataBase.Models;
using Horoko.InventoryManagment.Services.Mappers;
using Horoko.InventoryManagment.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Horoko.InventoryManagment.Services.Services
{
    public class GetDataService : IGetDataService
    {
        public IEnumerable<IngredientAmount> GetIngredientAmountData(string filePath)
        {
            List<IngredientAmount> records = new List<IngredientAmount>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<IngredientInfoMap>();
                    csvReader.Context.RegisterClassMap<IngredientAmountMap>();
                    csvReader.Context.RegisterClassMap<SalesRecordMap>();
                    records = csvReader.GetRecords<IngredientAmount>().ToList();
                }
            }
            return records;
        }

        public IEnumerable<IngredientInfo> GetIngredientInfoData(string filePath)
        {
            List<IngredientInfo> records = new List<IngredientInfo>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<IngredientInfoMap>();
                    csvReader.Context.RegisterClassMap<IngredientAmountMap>();
                    csvReader.Context.RegisterClassMap<SalesRecordMap>();
                    records = csvReader.GetRecords<IngredientInfo>().ToList();
                }
            }
            return records;
        }

        public IEnumerable<SalesRecord> GetSalesRecordData(string filePath)
        {
            List<SalesRecord> records = new List<SalesRecord>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<IngredientInfoMap>();
                    csvReader.Context.RegisterClassMap<IngredientAmountMap>();
                    csvReader.Context.RegisterClassMap<SalesRecordMap>();
                    records = csvReader.GetRecords<SalesRecord>().ToList();
                }
            }
            return records;
        }
    }
}
