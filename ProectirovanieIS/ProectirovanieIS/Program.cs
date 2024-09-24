class FuelPrice
{
    public string FuelType { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public string fuelprice {  get; set; }
}
/*class MyMath
{
    public static double CalculHyp(double a, double b)
    {
        return Math.Sqrt(a * a + b * b);
    }

   
} */
class Program
{
      static void Main(string[] args)
    /* {
         double sideA = 3.0;
         double sideB = 4.0;

         double hypotenuse = MyMath.CalculHyp(sideA, sideB);


         Console.WriteLine($"Длина гипотенузы: {hypotenuse:F2}");

     } */

    {
        Console.WriteLine("Введите текстовую строку в формате: \"Тип топлива\" \"Название топлива\" Дата Цена):");
     Console.WriteLine("Например:      Бензин AU-95 2023.05.15 56,99");
     string input = "'Бензин AU-95' 2023.05.15 56,99";
     Console.WriteLine();



     FuelPrice fuelPrice = ParseFuelPrice(input);

     Console.WriteLine($"мой бензин: {fuelPrice.fuelprice}");
     
     Console.WriteLine($"Тип топлива: {fuelPrice.FuelType}");
     Console.WriteLine($"Дата: {fuelPrice.Date.ToString("yyyy.MM.dd")}");
     Console.WriteLine($"Цена: {fuelPrice.Price}");

 }



    public static FuelPrice ParseFuelPrice(string input)
    {
        string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 4)
            throw new ArgumentException("Некорректный формат входной строки");

        string fuelType = parts[0].Trim('"') + " " + parts[1].Trim('"');
        DateTime date = DateTime.ParseExact(parts[2], "yyyy.MM.dd", null);
        decimal price = decimal.Parse(parts[3]);
        return new FuelPrice
        {
            FuelType = fuelType,
            Date = date,
            Price = price,
            fuelprice = fuelType + "   " + date + "   " + price + "   "
        };

    }
}

