using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class MillionaireTask : IConsoleTask
{
    public int Number => 3;

    public string Title => "Гра "Хто хоче стати мільйонером?"";

    public void Run()
    {
        ConsoleHelper.ShowPlaceholder(
            "ЗАВДАННЯ 3. ХТО ХОЧЕ СТАТИ МІЛЬЙОНЕРОМ?",
            "Гра міститиме 5 питань, по 4 варіанти відповіді та систему балів.");
    }
}
