namespace OOPConsoleInputOutputLab2.Common;

internal static class ConsoleHelper
{
    private const int HeaderWidth = 52;

    public static void WriteHeader(string title)
    {
        string border = new('=', HeaderWidth);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(border);
        Console.WriteLine(title);
        Console.WriteLine(border);
        Console.ResetColor();
        Console.WriteLine();
    }

    public static int ReadIntInRange(string prompt, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) &&
                value >= minValue &&
                value <= maxValue)
            {
                return value;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Помилка! Введіть ціле число від {minValue} до {maxValue}.");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public static void Pause(string message = "Натисніть Enter, щоб повернутися до головного меню...")
    {
        Console.WriteLine(message);
        Console.ReadLine();
    }

    public static void ShowPlaceholder(string title, string description)
    {
        Console.Clear();
        WriteHeader(title);
        Console.WriteLine(description);
        Console.WriteLine();
        Console.WriteLine("На цьому етапі підготовлено інтерфейс модуля.");
        Console.WriteLine("Алгоритм завдання буде додано на наступному етапі.");
        Console.WriteLine();
        Pause();
    }
}
