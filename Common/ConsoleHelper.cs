namespace OOPConsoleInputOutputLab2.Common;

internal static class ConsoleHelper
{
    private const int HeaderWidth = 52;

    public static void WriteHeader(string title)
    {
        string border = new('=', HeaderWidth);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(border);
        WriteCentered(title);
        Console.WriteLine(border);
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void WriteMainMenuHeader(string group, string title)
    {
        string border = new('=', HeaderWidth);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(border);
        WriteCentered($"ГРУПА {group}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteCentered(title);

        Console.ForegroundColor = ConsoleColor.Cyan;
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

    private static void WriteCentered(string text)
    {
        int leftPadding = Math.Max(0, (HeaderWidth - text.Length) / 2);
        Console.WriteLine($"{new string(' ', leftPadding)}{text}");
    }
}
