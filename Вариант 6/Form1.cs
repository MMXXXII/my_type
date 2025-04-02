using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Вариант_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            try
            {
                // Читаем текст из полей, если пусто, то присваиваем "0"
                string firstText = string.IsNullOrWhiteSpace(txtFirst.Text) ? "0" : txtFirst.Text;
                string secondText = string.IsNullOrWhiteSpace(txtSecond.Text) ? "0" : txtSecond.Text;

                // Выбор системы счисления для первого и второго числа
                int baseFirst = GetBaseFromComboBox(comboBox1.SelectedItem.ToString());
                int baseSecond = GetBaseFromComboBox(comboBox2.SelectedItem.ToString());

                // Проверка на правильность ввода в соответствии с выбранной системой счисления
                if (!IsValidInput(firstText, baseFirst) || !IsValidInput(secondText, baseSecond))
                {
                    txtResult.Text = "Неверный ввод!";
                    return;
                }

                // Преобразуем из строки в десятичное число в зависимости от выбранной системы счисления
                int firstValue = Convert.ToInt32(firstText, baseFirst);
                int secondValue = Convert.ToInt32(secondText, baseSecond);

                int resultValue = 0;

                // Выполнение выбранной операции
                switch (cmbOperation.Text)
                {
                    case "Сложение":
                        resultValue = firstValue + secondValue;
                        break;
                    case "Вычитание":
                        resultValue = firstValue - secondValue;
                        break;
                    case "Умножение":
                        resultValue = firstValue * secondValue;
                        break;
                    case "Сравнение":
                        txtResult.Text = firstValue == secondValue ? "Числа равны" : "Числа не равны";
                        return;
                    default:
                        resultValue = 0;
                        break;
                }

                // Выбор системы счисления для вывода результата
                int resultBase = GetBaseFromComboBox(comboBox3.SelectedItem.ToString()); // Результат в системе, выбранной в comboBox3

                string resultString = Convert.ToString(resultValue, resultBase).ToUpper();

                // Выводим результат в поле txtResult
                txtResult.Text = resultString;
            }
            catch (FormatException)
            {
                txtResult.Text = "Ошибка ввода";
            }
            catch (OverflowException)
            {
                txtResult.Text = "Слишком большое число";
            }
        }

        // Метод для получения базы из выбранной системы счисления
        private int GetBaseFromComboBox(string selectedItem)
        {
            switch (selectedItem)
            {
                case "Двоичная":
                    return 2;
                case "Восьмиричная":
                    return 8;
                case "Десятичная":
                    return 10;
                case "Шестнадцатиричная":
                    return 16;
                default:
                    return 10;
            }
        }

        // Метод для проверки корректности ввода
        private bool IsValidInput(string input, int numberBase)
        {
            string pattern = numberBase switch
            {
                2 => "^[01]*$",         // Для двоичной системы
                8 => "^[0-7]*$",         // Для восьмиричной системы
                10 => "^[0-9]*$",        // Для десятичной системы
                16 => "^[0-9A-Fa-f]*$",  // Для шестнадцатиричной системы
                _ => throw new ArgumentException("Неправильная система счисления")
            };

            return Regex.IsMatch(input, pattern);
        }

        // Обработчик изменения текста в первом поле
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate(); // Вызываем перерасчет
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate(); // Вызываем перерасчет
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate(); // Перерасчет при изменении первого комбо-бокса
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate(); // Перерасчет при изменении второго комбо-бокса
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate(); // Перерасчет при изменении третьего комбо-бокса (результат)
        }
    }
}
