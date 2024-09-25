
using PIS2;

{
    string[] inputData = File.ReadAllLines("C:\\Users\\User\\Desktop\\1.txt");

    List<FuelPrice> fuelPrices = new List<FuelPrice>();
    List<FuelStation> fuelStations = new List<FuelStation>();
    List<FuelDiscount> fuelDiscounts = new List<FuelDiscount>();

    foreach (string input in inputData)
    {
        try
        {
            if (input.Contains("'Бензин") || input.Contains("'Дизельное"))
            {
                FuelPrice fuelPrice = FuelPrice.ParseFuelPrice(input);
                fuelPrices.Add(fuelPrice);
            }
            else if (input.Contains("Заправка"))
            {
                FuelStation fuelStation = FuelStation.ParseFuelStation(input);
                fuelStations.Add(fuelStation);
            }
            else if (input.Contains("Бензин") || input.Contains("Дизельное"))
            {
                FuelDiscount fuelDiscount = FuelDiscount.ParseFuelDiscount(input);
                fuelDiscounts.Add(fuelDiscount);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке строки: {input}");
            Console.WriteLine(ex.Message);
        }
    }

   
    Console.WriteLine("Цены на топливо:");
    foreach (var price in fuelPrices)
    {
        Console.WriteLine($"{price.FuelType}, {price.Date:yyyy.MM.dd}, {price.Price} руб.");
    }

    Console.WriteLine("\nЗаправочные станции:");
    foreach (var station in fuelStations)
    {
        Console.WriteLine($"{station.StationName}, {station.Address}, {station.ContactInfo}");
    }

    Console.WriteLine("\nСкидки на топливо:");
    foreach (var discount in fuelDiscounts)
    {
        Console.WriteLine($"{discount.FuelType}, с {discount.StartDate:yyyy.MM.dd} по {discount.EndDate:yyyy.MM.dd}, скидка {discount.DiscountPercent}%");
    }
}