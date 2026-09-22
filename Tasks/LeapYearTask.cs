using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class LeapYearTask : IConsoleTask
{
    public int Number => 1;

    public string Title => "Перевірка року на високосність";

    public void Run()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("ЗАВДАННЯ 1. ВИСОКОСНИЙ РІК");

        int year = ReadYear();
        bool isLeapYear = IsLeapYear(year);

        Console.WriteLine();

        Console.ForegroundColor = isLeapYear
            ? ConsoleColor.Green
            : ConsoleColor.Cyan;

        Console.WriteLine(
            isLeapYear
                ? $"{year} рік є високосним."
                : $"{year} рік не є високосним.");

        Console.ResetColor();
        Console.WriteLine();
        ConsoleHelper.Pause();
    }

    private static int ReadYear()
    {
        while (true)
        {
            Console.Write("Введіть рік: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int year) && year > 0)
            {
                return year;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Помилка! Введіть додатний цілий номер року.");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    private static bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
        {
            return true;
        }

        if (year % 100 == 0)
        {
            return false;
        }

        return year % 4 == 0;
    }
}
