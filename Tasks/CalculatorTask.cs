using System.Globalization;
using OOPConsoleInputOutputLab2.Common;

namespace OOPConsoleInputOutputLab2.Tasks;

internal sealed class CalculatorTask : IConsoleTask
{
    public int Number => 4;

    public string Title => "Калькулятор";

    public void Run()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("ЗАВДАННЯ 4. КАЛЬКУЛЯТОР");

        Console.WriteLine("Підтримувані операції: +  -  *  /");
        Console.WriteLine("Множення та ділення виконуються раніше додавання та віднімання.");
        Console.WriteLine("Приклад: 5 + 5 * 10 + 4 / 2 - 3");
        Console.WriteLine("Алгоритм: Двухпроходный алгоритм вычисления арифметического выражения с предварительным разбором строки на числа и операторы (Помощник GPT)");

        while (true)
        {
            Console.Write("Введіть арифметичний вираз: ");
            string? expression = Console.ReadLine();

            if (!TryParseExpression(
                    expression,
                    out List<decimal> numbers,
                    out List<char> operators,
                    out string errorMessage))
            {
                ShowError(errorMessage);
                continue;
            }

            try
            {
                decimal result = Calculate(numbers, operators);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Результат: {FormatNumber(result)}");
                Console.ResetColor();
                Console.WriteLine();

                ConsoleHelper.Pause();
                return;
            }
            catch (DivideByZeroException)
            {
                ShowError("Ділення на нуль неможливе.");
            }
            catch (OverflowException)
            {
                ShowError("Результат виходить за допустимий діапазон чисел.");
            }
        }
    }

    private static bool TryParseExpression(
        string? expression,
        out List<decimal> numbers,
        out List<char> operators,
        out string errorMessage)
    {
        numbers = new List<decimal>();
        operators = new List<char>();
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(expression))
        {
            errorMessage = "Вираз не може бути порожнім.";
            return false;
        }

        int index = 0;
        bool expectNumber = true;

        while (index < expression.Length)
        {
            SkipSpaces(expression, ref index);

            if (index >= expression.Length)
            {
                break;
            }

            if (expectNumber)
            {
                int numberStartIndex = index;

                if (!TryReadNumber(expression, ref index, out decimal number))
                {
                    if (index > numberStartIndex)
                    {
                        errorMessage =
                            "Некоректне число або число виходить за допустимий діапазон.";
                        return false;
                    }

                    char unexpectedSymbol = expression[index];

                    errorMessage = IsOperator(unexpectedSymbol)
                        ? "Очікувалося число."
                        : $"Невідомий символ: '{unexpectedSymbol}'.";

                    return false;
                }

                numbers.Add(number);
                expectNumber = false;
            }
            else
            {
                char symbol = expression[index];

                if (!IsOperator(symbol))
                {
                    errorMessage = $"Невідомий символ або пропущений оператор: '{symbol}'.";
                    return false;
                }

                operators.Add(symbol);
                index++;
                expectNumber = true;
            }
        }

        if (numbers.Count == 0)
        {
            errorMessage = "Вираз повинен містити хоча б одне число.";
            return false;
        }

        if (expectNumber)
        {
            errorMessage = "Вираз не може закінчуватися оператором.";
            return false;
        }

        if (numbers.Count != operators.Count + 1)
        {
            errorMessage = "Некоректна послідовність чисел та операторів.";
            return false;
        }

        return true;
    }

    private static bool TryReadNumber(
        string expression,
        ref int index,
        out decimal number)
    {
        number = 0;

        int startIndex = index;
        bool hasDigit = false;
        bool hasDecimalSeparator = false;

        while (index < expression.Length)
        {
            char symbol = expression[index];

            if (char.IsDigit(symbol))
            {
                hasDigit = true;
                index++;
                continue;
            }

            if ((symbol == '.' || symbol == ',') && !hasDecimalSeparator)
            {
                hasDecimalSeparator = true;
                index++;
                continue;
            }

            break;
        }

        if (!hasDigit)
        {
            index = startIndex;
            return false;
        }

        string numberText = expression[startIndex..index].Replace(',', '.');

        return decimal.TryParse(
            numberText,
            NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out number);
    }

    private static decimal Calculate(
        List<decimal> numbers,
        List<char> operators)
    {
        List<decimal> reducedNumbers = new() { numbers[0] };
        List<char> reducedOperators = new();

        for (int index = 0; index < operators.Count; index++)
        {
            char operation = operators[index];
            decimal nextNumber = numbers[index + 1];

            if (operation == '*' || operation == '/')
            {
                decimal leftNumber = reducedNumbers[^1];

                if (operation == '/' && nextNumber == 0)
                {
                    throw new DivideByZeroException();
                }

                reducedNumbers[^1] = operation == '*'
                    ? leftNumber * nextNumber
                    : leftNumber / nextNumber;
            }
            else
            {
                reducedOperators.Add(operation);
                reducedNumbers.Add(nextNumber);
            }
        }

        decimal result = reducedNumbers[0];

        for (int index = 0; index < reducedOperators.Count; index++)
        {
            result = reducedOperators[index] == '+'
                ? result + reducedNumbers[index + 1]
                : result - reducedNumbers[index + 1];
        }

        return result;
    }

    private static bool IsOperator(char symbol)
    {
        return symbol is '+' or '-' or '*' or '/';
    }

    private static void SkipSpaces(string expression, ref int index)
    {
        while (index < expression.Length &&
               char.IsWhiteSpace(expression[index]))
        {
            index++;
        }
    }

    private static string FormatNumber(decimal number)
    {
        return number.ToString(
            "0.############################",
            CultureInfo.InvariantCulture);
    }

    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Помилка! {message}");
        Console.ResetColor();
        Console.WriteLine();
    }
}
