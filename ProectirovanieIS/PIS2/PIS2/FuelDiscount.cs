using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    internal class FuelDiscount
    {
        public string FuelType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercent { get; set; }

        public static FuelDiscount ParseFuelDiscount(string input)
        {
            
            input = input.Trim();            
            if (!input.StartsWith("\"") || !input.EndsWith("\""))
                throw new ArgumentException("Некорректный формат входной строки");           
            input = input.Substring(1, input.Length - 2);            
            string[] parts = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 4)
                throw new ArgumentException("Некорректный формат входной строки");
            string fuelType = parts[0];          
            if (DateTime.TryParseExact(parts[1], "yyyyMMdd", null, DateTimeStyles.None, out DateTime startDate) &&
                DateTime.TryParseExact(parts[2], "yyyyMMdd", null, DateTimeStyles.None, out DateTime endDate))
            {
                int discountPercent = int.Parse(parts[3]);

                return new FuelDiscount
                {
                    FuelType = fuelType,
                    StartDate = startDate,
                    EndDate = endDate,
                    DiscountPercent = discountPercent
                };
            }
            else
            {
                throw new FormatException("Некорректный формат даты в входной строке.");
            }
        }
    }
}
