using System.Text.RegularExpressions;

namespace Вариант_6
{
    public class NumberBaseOperations
    {
        public static int GetBase(string selectedItem)
        {
            return selectedItem switch
            {
                "Двоичная" => 2,
                "Восьмиричная" => 8,
                "Десятичная" => 10,
                "Шестнадцатиричная" => 16,
                _ => 10
            };
        }

        public static bool IsValidInput(string input, int numberBase)
        {
            string pattern = numberBase switch
            {
                2 => "^[01]*$",
                8 => "^[0-7]*$",
                10 => "^[0-9]*$",
                16 => "^[0-9A-Fa-f]*$",
                _ => throw new ArgumentException("Неправильная система счисления")
            };

            return Regex.IsMatch(input, pattern);
        }

        public static int ConvertToDecimal(string input, int numberBase)
        {
            return Convert.ToInt32(input, numberBase);
        }

        public static string ConvertFromDecimal(int value, int targetBase)
        {
            return Convert.ToString(value, targetBase).ToUpper();
        }

        public static string PerformOperation(int a, int b, string operation)
        {
            return operation switch
            {
                "Сложение" => (a + b).ToString(),
                "Вычитание" => (a - b).ToString(),
                "Умножение" => (a * b).ToString(),
                "Сравнение" => a == b ? "Числа равны" : "Числа не равны",
                _ => "Операция не выбрана"
            };
        }
    }
}
