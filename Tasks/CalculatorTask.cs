using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class CalculatorTask : IConsoleTask
{
    public int Number => 4;

    public string Title => "Калькулятор";

    public void Run()
    {
        ConsoleHelper.ShowPlaceholder(
            "ЗАВДАННЯ 4. КАЛЬКУЛЯТОР",
            "Програма обчислюватиме арифметичний вираз із правильним пріоритетом операцій.");
    }
}
