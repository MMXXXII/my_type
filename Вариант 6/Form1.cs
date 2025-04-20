using System;
using System.Windows.Forms;

namespace Вариант_6
{
    public partial class Form1 : Form
    {
        // Конструктор формы
        public Form1()
        {
            InitializeComponent();

            // Устанавливаем только начальный индекс для операции,
            // так как она точно имеет элементы, заданные в дизайнере
            if (cmbOperation.Items.Count > 0)
            {
                cmbOperation.SelectedIndex = 0;
            }
        }

        private void InputChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        // ... остальной код остается без изменений ...

        private void Calculate()
        {
            try
            {
                // Если оба поля пустые, показываем 0
                if (string.IsNullOrWhiteSpace(txtFirst.Text) && string.IsNullOrWhiteSpace(txtSecond.Text))
                {
                    txtResult.Text = "0";
                    return;
                }

                // Получаем системы счисления
                NumberSystem.NumberBase firstBase = GetBaseFromString(comboBox1.Text);
                NumberSystem.NumberBase secondBase = GetBaseFromString(comboBox2.Text);
                NumberSystem.NumberBase resultBase = GetBaseFromString(comboBox3.Text);

                // Функция проверки корректности ввода для заданной системы счисления
                bool IsValidForBase(string input, NumberSystem.NumberBase baseSystem)
                {
                    switch (baseSystem)
                    {
                        case NumberSystem.NumberBase.Binary:
                            return System.Text.RegularExpressions.Regex.IsMatch(input, "^[01]+$");
                        case NumberSystem.NumberBase.Octal:
                            return System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-7]+$");
                        case NumberSystem.NumberBase.Decimal:
                            return System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9]+$");
                        case NumberSystem.NumberBase.Hexadecimal:
                            return System.Text.RegularExpressions.Regex.IsMatch(input.ToUpper(), "^[0-9A-F]+$");
                        default:
                            return false;
                    }
                }

                // Если второе поле пустое, проверяем и показываем первое число
                if (string.IsNullOrWhiteSpace(txtSecond.Text))
                {
                    string input = txtFirst.Text;
                    if (!IsValidForBase(input, firstBase))
                    {
                        txtResult.Text = "Введена не та цифра";
                        return;
                    }
                    try
                    {
                        var firstNumber = new NumberSystem(input, firstBase);
                        txtResult.Text = firstNumber.ToBase(resultBase);
                    }
                    catch
                    {
                        txtResult.Text = "0";
                    }
                    return;
                }

                // Если первое поле пустое, проверяем и показываем второе число
                if (string.IsNullOrWhiteSpace(txtFirst.Text))
                {
                    string input = txtSecond.Text;
                    if (!IsValidForBase(input, secondBase))
                    {
                        txtResult.Text = "Введена не та цифра";
                        return;
                    }
                    try
                    {
                        var secondNumber = new NumberSystem(input, secondBase);
                        txtResult.Text = secondNumber.ToBase(resultBase);
                    }
                    catch
                    {
                        txtResult.Text = "0";
                    }
                    return;
                }

                // Проверяем корректность обоих чисел для их систем счисления
                if (!IsValidForBase(txtFirst.Text, firstBase) || !IsValidForBase(txtSecond.Text, secondBase))
                {
                    txtResult.Text = "Введена не та цифра";
                    return;
                }

                // Если оба поля заполнены корректно, выполняем выбранную операцию
                var num1 = new NumberSystem(txtFirst.Text, firstBase);
                var num2 = new NumberSystem(txtSecond.Text, secondBase);

                switch (cmbOperation.Text)
                {
                    case "Сложение":
                        var sum = num1 + num2;
                        txtResult.Text = sum.ToBase(resultBase);
                        break;

                    case "Вычитание":
                        var difference = num1 - num2;
                        txtResult.Text = difference.ToBase(resultBase);
                        break;

                    case "Умножение":
                        var product = num1 * num2;
                        txtResult.Text = product.ToBase(resultBase);
                        break;

                    case "Сравнение":
                        if (num1 == num2)
                            txtResult.Text = "Числа равны";
                        else
                            txtResult.Text = "Числа не равны";
                        break;
                }
            }
            catch
            {
                txtResult.Text = "Введена не та цифра";
            }
        }

        // Вспомогательный метод для преобразования русского названия системы счисления в NumberBase
        private NumberSystem.NumberBase GetBaseFromString(string baseStr)
        {
            switch (baseStr)
            {
                case "Двоичная":
                    return NumberSystem.NumberBase.Binary;
                case "Восьмиричная":
                    return NumberSystem.NumberBase.Octal;
                case "Десятичная":
                    return NumberSystem.NumberBase.Decimal;
                case "Шеснадцатиричная":
                    return NumberSystem.NumberBase.Hexadecimal;
                default:
                    return NumberSystem.NumberBase.Decimal;
            }
        }
    }
}