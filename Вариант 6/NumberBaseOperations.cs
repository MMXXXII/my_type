using System;
using System.Text.RegularExpressions;

namespace Вариант_6
{
    // Перечисление систем счисления
    public enum NumberBase
    {
        Binary = 2,       // Двоичная система
        Octal = 8,        // Восьмеричная система
        Decimal = 10,     // Десятичная система
        Hexadecimal = 16  // Шестнадцатеричная система
    }

    // Класс для операций с числами в разных системах счисления
    public class NumberBaseOperations
    {
        // Свойство: значение в десятичной системе
        public int Value { get; set; }

        // Конструктор, принимает значение
        public NumberBaseOperations(int value)
        {
            Value = value;
        }

        // Проверка валидности строки в заданной системе счисления
        public static bool IsValidInput(string input, int numberBase)
        {
            string allowedChars;

            // Определяем допустимые символы для каждой системы счисления
            switch (numberBase)
            {
                case 2:
                    allowedChars = "01";
                    break;
                case 8:
                    allowedChars = "01234567";
                    break;
                case 10:
                    allowedChars = "0123456789";
                    break;
                case 16:
                    allowedChars = "0123456789ABCDEFabcdef";
                    break;
                default:
                    throw new ArgumentException("Неправильная система счисления");
            }

            // Проверяем каждый символ входной строки
            foreach (char c in input)
            {
                if (!allowedChars.Contains(c))
                {
                    return false; // Недопустимый символ
                }
            }

            return true; // Все символы допустимы
        }

        // Преобразование строки из заданной системы счисления в десятичную
        public static int ConvertToDecimal(string input, NumberBase numberBase)
        {
            return Convert.ToInt32(input, (int)numberBase);
        }

        // Преобразование десятичного числа в строку в целевой системе счисления
        public static string ConvertFromDecimal(int value, NumberBase targetBase)
        {
            return Convert.ToString(value, (int)targetBase).ToUpper();
        }

        // Выполнение арифметической или логической операции над двумя числами
        public static string PerformOperation(int a, int b, string operation)
        {
            // Создание объектов для чисел
            NumberBaseOperations opA = new NumberBaseOperations(a);
            NumberBaseOperations opB = new NumberBaseOperations(b);

            string result; // Строка для хранения результата

            // Выполняем выбранную операцию
            if (operation == "Сложение")
            {
                NumberBaseOperations sum = opA + opB;
                result = sum.Value.ToString();
            }
            else if (operation == "Вычитание")
            {
                NumberBaseOperations difference = opA - opB;
                result = difference.Value.ToString();
            }
            else if (operation == "Умножение")
            {
                NumberBaseOperations product = opA * opB;
                result = product.Value.ToString();
            }
            else if (operation == "Деление")
            {
                if (b == 0)
                {
                    result = "Деление на ноль";
                }
                else
                {
                    NumberBaseOperations division = opA / opB;
                    result = division.Value.ToString();
                }
            }
            else if (operation == "Сравнение")
            {
                // Сравнение чисел
                if (a == b)
                {
                    result = "Числа равны";
                }
                else
                {
                    result = "Числа не равны";
                }
            }
            else
            {
                result = "Операция не выбрана";
            }

            return result; // Возврат результата
        }

        // Перегрузка оператора сложения
        public static NumberBaseOperations operator +(NumberBaseOperations a, NumberBaseOperations b)
        {
            return new NumberBaseOperations(a.Value + b.Value);
        }

        // Перегрузка оператора вычитания
        public static NumberBaseOperations operator -(NumberBaseOperations a, NumberBaseOperations b)
        {
            return new NumberBaseOperations(a.Value - b.Value);
        }

        // Перегрузка оператора умножения
        public static NumberBaseOperations operator *(NumberBaseOperations a, NumberBaseOperations b)
        {
            return new NumberBaseOperations(a.Value * b.Value);
        }

        // Перегрузка оператора деления
        public static NumberBaseOperations operator /(NumberBaseOperations a, NumberBaseOperations b)
        {
            if (b.Value == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");

            return new NumberBaseOperations(a.Value / b.Value);
        }
    }
}
