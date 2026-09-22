namespace OOPConsoleInputOutputLab2.Models;

internal sealed class Question
{
    public Question(string text, string[] answers, int correctAnswerNumber)
    {
        if (answers.Length != 4)
        {
            throw new ArgumentException(
                "Кожне питання повинно мати рівно 4 варіанти відповіді.",
                nameof(answers));
        }

        if (correctAnswerNumber < 1 || correctAnswerNumber > 4)
        {
            throw new ArgumentOutOfRangeException(
                nameof(correctAnswerNumber),
                "Номер правильної відповіді повинен бути від 1 до 4.");
        }

        Text = text;
        Answers = answers;
        CorrectAnswerNumber = correctAnswerNumber;
    }

    public string Text { get; }

    public string[] Answers { get; }

    public int CorrectAnswerNumber { get; }
}
