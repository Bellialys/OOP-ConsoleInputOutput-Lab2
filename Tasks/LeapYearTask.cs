using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class LeapYearTask : IConsoleTask
{
    public int Number => 1;

    public string Title => "Перевірка року на високосність";

    public void Run()
    {
        ConsoleHelper.ShowPlaceholder(
            "ЗАВДАННЯ 1. ВИСОКОСНИЙ РІК",
            "Програма визначатиме, чи є введений користувачем рік високосним.");
    }
}
