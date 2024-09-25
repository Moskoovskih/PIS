using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class FuelPrice
    {
        public string FuelType { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public static FuelPrice ParseFuelPrice(string input)
        {
            
            input = input.Trim();            
            if (!input.StartsWith("'") || !input.EndsWith("'"))
                throw new ArgumentException("Некорректный формат входной строки");          
            input = input.Substring(1, input.Length - 2);            
            string[] parts = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
                throw new ArgumentException("Некорректный формат входной строки");
            string fuelType = parts[0];
            DateTime date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);          
            if (decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                return new FuelPrice
                {
                    FuelType = fuelType,
                    Date = date,
                    Price = price
                };
            }
            else
            {
                throw new FormatException($"Невозможно преобразовать '{parts[2]}' в десятичное число.");
            }
        }
    }
}
