using System;
using System.Text.RegularExpressions;

namespace Вариант_6
{
    public class NumberBaseOperations
    {
        // Метод для получения основания системы счисления по строковому значению
        public static int GetBase(string selectedItem)
        {
            if (selectedItem == "Двоичная")
            {
                return 2;
            }
            else if (selectedItem == "Восьмиричная")
            {
                return 8;
            }
            else if (selectedItem == "Десятичная")
            {
                return 10;
            }
            else if (selectedItem == "Шеснадцатиричная")
            {
                return 16;
            }
            else
            {
                return 10; // по умолчанию десятичная система счисления
            }
        }

        // Метод для проверки валидности введённого значения в зависимости от системы счисления
        public static bool IsValidInput(string input, int numberBase)
        {
            string pattern = "";

            if (numberBase == 2)
            {
                pattern = "^[01]*$";
            }
            else if (numberBase == 8)
            {
                pattern = "^[0-7]*$";
            }
            else if (numberBase == 10)
            {
                pattern = "^[0-9]*$";
            }
            else if (numberBase == 16)
            {
                pattern = "^[0-9A-Fa-f]*$";
            }
            else
            {
                throw new ArgumentException("Неправильная система счисления");
            }

            return Regex.IsMatch(input, pattern);
        }

        // Метод для преобразования числа из выбранной системы счисления в десятичную
        public static int ConvertToDecimal(string input, int numberBase)
        {
            return Convert.ToInt32(input, numberBase);
        }

        // Метод для преобразования числа из десятичной системы счисления в целевую систему счисления
        public static string ConvertFromDecimal(int value, int targetBase)
        {
            return Convert.ToString(value, targetBase).ToUpper(); // Преобразуем в строку и приводим к верхнему регистру
        }

        // Метод для выполнения математических операций
        public static string PerformOperation(int a, int b, string operation)
        {
            if (operation == "Сложение")
            {
                return (a + b).ToString();
            }
            else if (operation == "Вычитание")
            {
                return (a - b).ToString();
            }
            else if (operation == "Умножение")
            {
                return (a * b).ToString();
            }
            else if (operation == "Сравнение")
            {
                if (a == b)
                {
                    return "Числа равны";
                }
                else
                {
                    return "Числа не равны";
                }
            }
            else
            {
                return "Операция не выбрана";
            }
        }
    }
}
