using System.Text.RegularExpressions;

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
                // Читаем текст из первого поля
                string firstText;
                if (string.IsNullOrWhiteSpace(txtFirst.Text))
                {
                    firstText = "0";
                }
                else
                {
                    firstText = txtFirst.Text;
                }

                // Читаем текст из второго поля
                string secondText;
                if (string.IsNullOrWhiteSpace(txtSecond.Text))
                {
                    secondText = "0";
                }
                else
                {
                    secondText = txtSecond.Text;
                }

                // Получаем основание системы счисления из первого выпадающего списка
                string selectedItem1 = comboBox1.SelectedItem.ToString();
                int baseFirst = GetBaseFromComboBox(selectedItem1);

                // Получаем основание системы счисления из второго выпадающего списка
                string selectedItem2 = comboBox2.SelectedItem.ToString();
                int baseSecond = GetBaseFromComboBox(selectedItem2);

                // Проверяем, правильные ли данные введены
                bool isFirstValid = IsValidInput(firstText, baseFirst);
                bool isSecondValid = IsValidInput(secondText, baseSecond);

                if (isFirstValid == false || isSecondValid == false)
                {
                    txtResult.Text = "Неверный ввод!";
                    return;
                }

                // Преобразуем строки в целые числа (в десятичной системе)
                int firstValue = Convert.ToInt32(firstText, baseFirst);
                int secondValue = Convert.ToInt32(secondText, baseSecond);

                // Объявляем переменную для хранения результата
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
                        if (firstValue == secondValue)
                        {
                            txtResult.Text = "Числа равны";
                        }
                        else
                        {
                            txtResult.Text = "Числа не равны";
                        }
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
            string pattern = "";

            if (numberBase == 2)
                pattern = "^[01]*$"; // Только 0 и 1
            else if (numberBase == 8)
                pattern = "^[0-7]*$"; // Только от 0 до 7
            else if (numberBase == 10)
                pattern = "^[0-9]*$"; // Только цифры
            else if (numberBase == 16)
                pattern = "^[0-9A-Fa-f]*$"; // Цифры и буквы от A до F
            else
                throw new ArgumentException("Неправильная система счисления");

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
