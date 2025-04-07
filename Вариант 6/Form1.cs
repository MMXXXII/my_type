using System;
using System.Windows.Forms;

namespace Вариант_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Навешиваем события (если не сделано в дизайнере)
            txtFirst.TextChanged += InputChanged;
            txtSecond.TextChanged += InputChanged;
            cmbOperation.SelectedIndexChanged += InputChanged;
            comboBox1.SelectedIndexChanged += InputChanged;
            comboBox2.SelectedIndexChanged += InputChanged;
            comboBox3.SelectedIndexChanged += InputChanged;
        }

        private void InputChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                // Получаем текст из полей, если пусто — заменяем на 0
                string firstText = string.IsNullOrWhiteSpace(txtFirst.Text) ? "0" : txtFirst.Text;
                string secondText = string.IsNullOrWhiteSpace(txtSecond.Text) ? "0" : txtSecond.Text;

                // Определяем основания систем счисления
                int baseFirst = NumberBaseOperations.GetBase(comboBox1.SelectedItem?.ToString() ?? "Десятичная");
                int baseSecond = NumberBaseOperations.GetBase(comboBox2.SelectedItem?.ToString() ?? "Десятичная");
                int baseResult = NumberBaseOperations.GetBase(comboBox3.SelectedItem?.ToString() ?? "Десятичная");

                // Проверка на валидность ввода
                if (!NumberBaseOperations.IsValidInput(firstText, baseFirst) ||
                    !NumberBaseOperations.IsValidInput(secondText, baseSecond))
                {
                    txtResult.Text = "Неверный ввод!";
                    return;
                }

                // Переводим в десятичную
                int firstValue = NumberBaseOperations.ConvertToDecimal(firstText, baseFirst);
                int secondValue = NumberBaseOperations.ConvertToDecimal(secondText, baseSecond);

                // Выполняем операцию
                string operation = cmbOperation.Text;
                string result = NumberBaseOperations.PerformOperation(firstValue, secondValue, operation);

                // Если сравнение — выводим строку
                if (operation == "Сравнение")
                {
                    txtResult.Text = result;
                    return;
                }

                // Остальные операции — это числа, их надо перевести в нужную систему
                int resultValue = int.Parse(result);
                txtResult.Text = NumberBaseOperations.ConvertFromDecimal(resultValue, baseResult);
            }
            catch (FormatException)
            {
                txtResult.Text = "Ошибка ввода";
            }
            catch (OverflowException)
            {
                txtResult.Text = "Слишком большое число";
            }
            catch (Exception)
            {
                txtResult.Text = "Непредвиденная ошибка";
            }
        }
    }
}
