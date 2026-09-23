using OOPConsoleInputOutputLab2.Common;
using OOPConsoleInputOutputLab2.Models;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class MillionaireTask : IConsoleTask
{
    private const int PointsPerCorrectAnswer = 100;

    private static readonly Question[] DemoQuestions =
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

    // Питання адаптовано українською за мотивами реальних випусків
    // телевікторини «Хто хоче стати мільйонером?».
    private static readonly Question[] FullGameQuestions =
    {
        new(
            "Чим часто писали до появи кулькових ручок?",
            new[] { "Пухом", "Хутром", "Пір'ям", "Лускою" },
            3),

        new(
            "Що потрібно для дитячої гри в класики?",
            new[] { "Боксерський ринг", "Клітинки на асфальті", "Партитура", "Зібрання творів" },
            2),

        new(
            "До якого соку традиційно можуть додавати сіль за смаком?",
            new[] { "Яблучного", "Апельсинового", "Грушевого", "Томатного" },
            4),

        new(
            "Чого практично немає у кішок породи бобтейл?",
            new[] { "Вух", "Вусів", "Хвоста", "Кігтів" },
            3),

        new(
            "Хто розписував стелю Сикстинської капели?",
            new[] { "Леонардо да Вінчі", "Рафаель", "Мікеланджело", "Тіціан" },
            3),

        new(
            "На честь яких тварин отримав назву резус-фактор?",
            new[] { "Мишей", "Мавп", "Собак", "Корів" },
            2),

        new(
            "Якого прізвища немає серед персонажів роману «Майстер і Маргарита»?",
            new[] { "Берліоз", "Римський", "Стравінський", "Мусоргський" },
            4),

        new(
            "Що означає «лінія» у назві трилінійної гвинтівки Мосіна?",
            new[] { "Наріз у стволі", "Одиницю маси", "Одиницю довжини", "Мушку прицілу" },
            3),

        new(
            "У якому озері живе майже прозора рибка голом'янка?",
            new[] { "Селігер", "Таймир", "Байкал", "Онезьке" },
            3),

        new(
            "Кому Бетховен спочатку присвятив свою «Героїчну симфонію»?",
            new[] { "Блюхеру", "Веллінгтону", "Наполеону", "Леопольду II" },
            3),

        new(
            "Кому належав кінь на прізвисько Маренго?",
            new[] { "Олександру Македонському", "Карлу XII", "Олександру Суворову", "Наполеону Бонапарту" },
            4),

        new(
            "Ким працювала Раїса Кудашева, коли написала рядки майбутньої пісні про ялинку?",
            new[] { "Кухаркою", "Гувернанткою", "Учителькою музики", "Телефоністкою" },
            2),

        new(
            "За дослідження якої системи комунікації Карл фон Фріш отримав Нобелівську премію?",
            new[] { "Мурах", "Дельфінів", "Кажанів", "Бджіл" },
            4),

        new(
            "У якому місті 1932 року відбувся перший міжнародний кінофестиваль?",
            new[] { "Канни", "Венеція", "Париж", "Берлін" },
            2),

        new(
            "Який вид кавалерії міг вести бій і верхи, і в пішому строю?",
            new[] { "Кірасири", "Улани", "Драгуни", "Гусари" },
            3)
    };

    public int Number => 3;

    public string Title => "Гра «Хто хоче стати мільйонером?»";

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteHeader("ХТО ХОЧЕ СТАТИ МІЛЬЙОНЕРОМ?");

            Console.WriteLine("1. Демо-версія (навчальна) — 5 питань");
            Console.WriteLine("2. Повна гра — 15 питань за мотивами реальних випусків");
            Console.WriteLine("0. Повернутися до головного меню");
            Console.WriteLine();

            int choice = ConsoleHelper.ReadIntInRange(
                "Оберіть режим: ",
                0,
                2);

            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    RunQuiz(
                        "ДЕМО-ВЕРСІЯ",
                        DemoQuestions,
                        "Навчальний режим: усі питання проходяться до кінця.");
                    return;
                case 2:
                    RunQuiz(
                        "ПОВНА ГРА",
                        FullGameQuestions,
                        "15 питань зі зростанням складності. Помилка не перериває гру.");
                    return;
            }
        }
    }

    private static void RunQuiz(
        string modeTitle,
        Question[] questions,
        string description)
    {
        Console.Clear();
        ConsoleHelper.WriteHeader($"ЗАВДАННЯ 3. {modeTitle}");

        Console.WriteLine(description);
        Console.WriteLine($"За кожну правильну відповідь ви отримуєте {PointsPerCorrectAnswer} балів.");
        Console.WriteLine();

        int score = 0;

        for (int index = 0; index < questions.Length; index++)
        {
            Question question = questions[index];

            ShowQuestion(question, index + 1, questions.Length, score);

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

        int maxScore = questions.Length * PointsPerCorrectAnswer;

        Console.ForegroundColor = score == maxScore
            ? ConsoleColor.Green
            : ConsoleColor.Cyan;

        Console.WriteLine(
            score == maxScore
                ? $"Вітаємо! Ви правильно відповіли на всі {questions.Length} питань!"
                : $"Гру завершено! Ви відповіли на всі {questions.Length} питань.");

        Console.ResetColor();
        Console.WriteLine();

        ShowFinalScore(score, maxScore);
        ConsoleHelper.Pause();
    }

    private static void ShowQuestion(
        Question question,
        int questionNumber,
        int totalQuestions,
        int score)
    {
        Console.WriteLine($"Питання {questionNumber} з {totalQuestions}");
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

    private static void ShowFinalScore(int score, int maxScore)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Ваш підсумковий рахунок: {score} із {maxScore} балів.");
        Console.ResetColor();
        Console.WriteLine();
    }
}
