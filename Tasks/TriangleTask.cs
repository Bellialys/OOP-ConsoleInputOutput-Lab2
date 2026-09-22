using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class TriangleTask : IConsoleTask
{
    public int Number => 2;

    public string Title => "Побудова числового трикутника";

    public void Run()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("ЗАВДАННЯ 2. ЧИСЛОВИЙ ТРИКУТНИК");

        int height = ReadHeight();

        Console.WriteLine();
        DrawTriangle(height);
        Console.WriteLine();

        ConsoleHelper.Pause();
    }

    private static int ReadHeight()
    {
        while (true)
        {
            Console.Write("Введіть висоту трикутника: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int height) && height > 0)
            {
                return height;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Помилка! Введіть додатну цілу висоту трикутника.");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    private static void DrawTriangle(int height)
    {
        int numberWidth = height.ToString().Length;
        int cellWidth = numberWidth + 1;

        for (int row = 1; row <= height; row++)
        {
            int indent = (height - row) * cellWidth;
            Console.Write(new string(' ', indent));

            for (int column = 1; column <= row; column++)
            {
                Console.Write(row.ToString().PadLeft(numberWidth));

                if (column < row)
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();
        }
    }
}
