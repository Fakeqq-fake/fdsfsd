using System;

public interface IConverter
{
    double Convert(double value);
    string GetFromUnit();
    string GetToUnit();
}

public class LengthConverter : IConverter
{
    public double Convert(double meters)
    {
        return meters * 3.28084; 
    }

    public string GetFromUnit()
    {
        return "метры";
    }

    public string GetToUnit()
    {
        return "футы";
    }
}

public class WeightConverter : IConverter
{
    public double Convert(double kilograms)
    {
        return kilograms * 2.20462;
    }

    public string GetFromUnit()
    {
        return "килограммы";
    }

    public string GetToUnit()
    {
        return "фунты";
    }
}

public class TemperatureConverter : IConverter
{
    public double Convert(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public string GetFromUnit()
    {
        return "Цельсий (°C)";
    }

    public string GetToUnit()
    {
        return "Фаренгейт (°F)";
    }
}

public class ConverterProcessor
{
    public void PerformConversion(IConverter converter, double value)
    {
        double result = converter.Convert(value);
        Console.WriteLine($"{value} {converter.GetFromUnit()} = {result:F2} {converter.GetToUnit()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== СИСТЕМА КОНВЕРТАЦИИ ВЕЛИЧИН ===");
        Console.WriteLine();

        IConverter lengthConverter = new LengthConverter();
        IConverter weightConverter = new WeightConverter();
        IConverter temperatureConverter = new TemperatureConverter();

        ConverterProcessor processor = new ConverterProcessor();

        Console.WriteLine("=== ДЕМОНСТРАЦИЯ ПОЛИМОРФИЗМА ===");
        Console.WriteLine();

        processor.PerformConversion(lengthConverter, 10); 
        processor.PerformConversion(weightConverter, 50); 
        processor.PerformConversion(temperatureConverter, 25); 

        Console.WriteLine();
        Console.WriteLine("=== КОНВЕРТАЦИЯ ЧЕРЕЗ МАССИВ (ещё одна демонстрация полиморфизма) ===");
        Console.WriteLine();

        IConverter[] converters = { lengthConverter, weightConverter, temperatureConverter };
        double[] values = { 2, 15, 0 };
        for (int i = 0; i < converters.Length; i++)
        {
            processor.PerformConversion(converters[i], values[i]);
        }

        Console.WriteLine();
        Console.WriteLine("Все конвертации успешно выполнены!");

        Console.WriteLine();
        Console.WriteLine("=== ИНТЕРАКТИВНАЯ КОНВЕРТАЦИЯ ===");
        RunInteractiveConversion();
    }

    static void RunInteractiveConversion()
    {
        IConverter[] converters = {
            new LengthConverter(),
            new WeightConverter(),
            new TemperatureConverter()
        };

        Console.WriteLine("Выберите тип конвертации:");
        Console.WriteLine("1. Метры → Футы");
        Console.WriteLine("2. Килограммы → Фунты");
        Console.WriteLine("3. Цельсий → Фаренгейт");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
        {
            Console.Write("Введите значение для конвертации: ");
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                ConverterProcessor processor = new ConverterProcessor();
                processor.PerformConversion(converters[choice - 1], value);
            }
            else
            {
                Console.WriteLine("Некорректное значение!");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор!");
        }
    }
}
