using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class TriangleTask : IConsoleTask
{
    public int Number => 2;

    public string Title => "Побудова числового трикутника";

    public void Run()
    {
        ConsoleHelper.ShowPlaceholder(
            "ЗАВДАННЯ 2. ЧИСЛОВИЙ ТРИКУТНИК",
            "Програма будуватиме числовий трикутник заданої користувачем висоти.");
    }
}
