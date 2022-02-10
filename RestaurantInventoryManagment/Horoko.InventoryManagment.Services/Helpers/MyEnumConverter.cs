using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace Horoko.InventoryManagment.Services
{
    public class MyEnumConverter<T> : EnumConverter where T : struct
    {
        public MyEnumConverter() : base(typeof(T)) { }
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!Enum.TryParse(text, out T enumValue))
            {
                throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(T)} Value: {text}");
            }

            return enumValue;
        }
    }
}
