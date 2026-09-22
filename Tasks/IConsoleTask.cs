namespace OOPConsoleInputOutputLab2.Tasks;

internal interface IConsoleTask
{
    int Number { get; }

    string Title { get; }

    void Run();
}
