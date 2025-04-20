using System;
using System.Windows.Forms;

namespace Вариант_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperation.SelectedIndex = 0;
        }

        private void InputChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        // Основной метод вычислений
        private void Calculate()
        {
            // Если оба поля пустые - выводим 0
            if (string.IsNullOrEmpty(txtFirst.Text) && string.IsNullOrEmpty(txtSecond.Text))
            {
                txtResult.Text = "0";
                return;
            }

                // Получаем системы счисления
                int firstBase = NumberSystem.GetBaseFromString(comboBox1.Text);
                int secondBase = NumberSystem.GetBaseFromString(comboBox2.Text);
                int resultBase = NumberSystem.GetBaseFromString(comboBox3.Text);

                // Если второе число пустое - просто конвертируем первое
                if (string.IsNullOrEmpty(txtSecond.Text))
                {
                    if (!NumberSystem.IsValidInput(txtFirst.Text, firstBase))
                    {
                        txtResult.Text = "Введена не та цифра";
                        return;
                    }

                    var num = new NumberSystem(txtFirst.Text, firstBase);
                    txtResult.Text = num.ToBase(resultBase);
                    return;
                }

                // Если первое число пустое - просто конвертируем второе
                if (string.IsNullOrEmpty(txtFirst.Text))
                {
                    if (!NumberSystem.IsValidInput(txtSecond.Text, secondBase))
                    {
                        txtResult.Text = "Введена не та цифра";
                        return;
                    }

                    var num = new NumberSystem(txtSecond.Text, secondBase);
                    txtResult.Text = num.ToBase(resultBase);
                    return;
                }

                // Проверяем правильность обоих чисел
                if (!NumberSystem.IsValidInput(txtFirst.Text, firstBase) ||
                    !NumberSystem.IsValidInput(txtSecond.Text, secondBase))
                {
                    txtResult.Text = "Введена не та цифра";
                    return;
                }

                // Создаем числа
                var num1 = new NumberSystem(txtFirst.Text, firstBase);
                var num2 = new NumberSystem(txtSecond.Text, secondBase);

                // Выполняем операцию
                if (cmbOperation.Text == "Сложение")
                {
                    // Складываем числа и переводим результат в нужную систему счисления
                    NumberSystem result = num1 + num2;
                    txtResult.Text = result.ToBase(resultBase);
                }
                else if (cmbOperation.Text == "Вычитание")
                {
                    // Вычитаем числа и переводим результат в нужную систему счисления
                    NumberSystem result = num1 - num2;
                    txtResult.Text = result.ToBase(resultBase);
                }
                else if (cmbOperation.Text == "Умножение")
                {
                    // Умножаем числа и переводим результат в нужную систему счисления
                    NumberSystem result = num1 * num2;
                    txtResult.Text = result.ToBase(resultBase);
                }
                else if (cmbOperation.Text == "Сравнение")
                {
                    // Сравниваем числа и выводим текстовый результат
                    if (num1 == num2)
                    {
                        txtResult.Text = "Числа равны";
                    }
                    else
                    {
                        txtResult.Text = "Числа не равны";
                    }
                }
                else
                {
                    // Если операция не выбрана
                    txtResult.Text = "Выберите операцию";
                }
            }
        }
    }
