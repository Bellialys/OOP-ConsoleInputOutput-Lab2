using System.Text;
using OOPConsoleInputOutputLab2.Common;
using OOPConsoleInputOutputLab2.Tasks;

namespace OOPConsoleInputOutputLab2;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "ООП — Консольні додатки Input/Output";

        IConsoleTask[] tasks =
        {
            new LeapYearTask(),
            new TriangleTask(),
            new MillionaireTask(),
            new CalculatorTask()
        };

        ShowSplashScreen();
        RunMainMenu(tasks);
    }

    private static void ShowSplashScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║        ОБ'ЄКТНО-ОРІЄНТОВАНЕ                ║");
        Console.WriteLine("║             ПРОГРАМУВАННЯ                  ║");
        Console.WriteLine("║                                            ║");
        Console.WriteLine("║       Консольні додатки Input/Output       ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("            Навчальний проєкт на C#");
        Console.WriteLine();

        ConsoleHelper.Pause("Натисніть Enter, щоб перейти до головного меню...");
    }

    private static void RunMainMenu(IConsoleTask[] tasks)
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteMainMenuHeader("ФІТ-2-15", "ГОЛОВНЕ МЕНЮ");

            foreach (IConsoleTask task in tasks)
            {
                Console.WriteLine($"{task.Number}. {task.Title}");
            }

            Console.WriteLine("0. Вихід");
            Console.WriteLine();

            int choice = ConsoleHelper.ReadIntInRange(
                "Оберіть завдання: ",
                0,
                tasks.Length);

            if (choice == 0)
            {
                ShowExitScreen();
                return;
            }

            tasks[choice - 1].Run();
        }
    }

    private static void ShowExitScreen()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("ЗАВЕРШЕННЯ РОБОТИ");
        Console.WriteLine("Дякуємо за використання програми!");
        Console.WriteLine();
    }
}
