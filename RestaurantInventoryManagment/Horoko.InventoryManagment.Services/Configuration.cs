using Newtonsoft.Json;
using System.IO;

namespace Horoko.InventoryManagment.Services
{
    public class Configuration
    {
        public string IngredientInfoFilePath { get; set; }
        public string IngredientAmoutFilePath { get; set; }
        public string SalesRecordsFilePath { get; set; }
    }

    public static class Config
    {
        private static readonly Configuration _config;
        static Config()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Damjan Stojanovski\source\repos\Horoko.InventoryManagment\Horoko.InventoryManagment.Console\config.json"))
            {
                var json = r.ReadToEnd();
                _config = JsonConvert.DeserializeObject<Configuration>(json);
            }
        }
        public static string IngredientInfoFilePath 
        {
            get 
            {
                return _config.IngredientInfoFilePath;
            }
        }

        public static string IngredientAmoutFilePath
        {
            get
            {
                return _config.IngredientAmoutFilePath;
            }
        }

        public static string SalesRecordsFilePath
        {
            get
            {
                return _config.SalesRecordsFilePath;
            }
        }
    }
}
