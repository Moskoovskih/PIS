using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class FuelStation
    {
        public string StationName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public static FuelStation ParseFuelStation(string input)
        {

            input = input.Trim();
            string[] parts = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
                throw new ArgumentException("Некорректный формат входной строки");
            string stationName = string.Join(" ", parts, 0, parts.Length - 2);
            string address = parts[parts.Length - 2];
            string contactInfo = parts[parts.Length - 1];

            return new FuelStation
            {
                StationName = stationName,
                Address = address,
                ContactInfo = contactInfo
            };
        }
    }
}
