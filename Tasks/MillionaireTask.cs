using OOPConsoleInputOutputLab2.Common;
using OOPConsoleInputOutputLab2.Models;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class MillionaireTask : IConsoleTask
{
    private const int PointsPerCorrectAnswer = 100;

    private static readonly Question[] Questions =
    {
        new(
            "З яких кольорів складається прапор України?",
            new[]
            {
                "Червоного та білого",
                "Синього та жовтого",
                "Зеленого та чорного",
                "Білого та синього"
            },
            2),

        new(
            "У якому місті знаходиться Державний торговельно-економічний університет (ДТЕУ)?",
            new[]
            {
                "Львів",
                "Одеса",
                "Київ",
                "Харків"
            },
            3),

        new(
            "Яке ключове слово використовується для оголошення класу в C#?",
            new[]
            {
                "object",
                "class",
                "method",
                "namespace"
            },
            2),

        new(
            "Який цикл виконується доти, доки його умова має значення true?",
            new[]
            {
                "if",
                "switch",
                "while",
                "return"
            },
            3),

        new(
            "Який оператор у C# повертає остачу від ділення?",
            new[]
            {
                "/",
                "*",
                "%",
                "+"
            },
            3)
    };

    public int Number => 3;

    public string Title => "Гра «Хто хоче стати мільйонером?»";

    public void Run()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("ЗАВДАННЯ 3. ХТО ХОЧЕ СТАТИ МІЛЬЙОНЕРОМ?");

        Console.WriteLine("Дайте відповіді на всі 5 питань.");
        Console.WriteLine($"За кожну правильну відповідь ви отримуєте {PointsPerCorrectAnswer} балів.");
        Console.WriteLine("Неправильна відповідь не завершує гру — наступне питання все одно буде показано.");
        Console.WriteLine();

        int score = 0;

        for (int index = 0; index < Questions.Length; index++)
        {
            Question question = Questions[index];

            ShowQuestion(question, index + 1, score);

            int answer = ConsoleHelper.ReadIntInRange(
                "Ваша відповідь (1-4): ",
                1,
                4);

            Console.WriteLine();

            if (answer == question.CorrectAnswerNumber)
            {
                score += PointsPerCorrectAnswer;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Правильна відповідь! Поточний рахунок: {score} балів.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильна відповідь! За це питання нараховано 0 балів.");
                Console.ResetColor();

                Console.WriteLine(
                    $"Правильна відповідь: " +
                    $"{question.CorrectAnswerNumber}. " +
                    $"{question.Answers[question.CorrectAnswerNumber - 1]}");
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = score == Questions.Length * PointsPerCorrectAnswer
            ? ConsoleColor.Green
            : ConsoleColor.Cyan;

        Console.WriteLine(
            score == Questions.Length * PointsPerCorrectAnswer
                ? "Вітаємо! Ви правильно відповіли на всі 5 питань!"
                : "Гру завершено! Ви відповіли на всі 5 питань.");

        Console.ResetColor();
        Console.WriteLine();

        ShowFinalScore(score);
        ConsoleHelper.Pause();
    }

    private static void ShowQuestion(Question question, int questionNumber, int score)
    {
        Console.WriteLine($"Питання {questionNumber} з {Questions.Length}");
        Console.WriteLine($"Рахунок: {score} балів");
        Console.WriteLine();
        Console.WriteLine(question.Text);
        Console.WriteLine();

        for (int index = 0; index < question.Answers.Length; index++)
        {
            Console.WriteLine($"{index + 1}. {question.Answers[index]}");
        }

        Console.WriteLine();
    }

    private static void ShowFinalScore(int score)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Ваш підсумковий рахунок: {score} із {Questions.Length * PointsPerCorrectAnswer} балів.");
        Console.ResetColor();
        Console.WriteLine();
    }
}
