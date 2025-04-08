namespace Вариант_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void InputChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                // Получаем значения из текстовых полей, если пусто — ставим 0
                string firstInput = txtFirst.Text;
                string secondInput = txtSecond.Text;

                if (string.IsNullOrWhiteSpace(firstInput))
                {
                    firstInput = "0";
                }

                if (string.IsNullOrWhiteSpace(secondInput))
                {
                    secondInput = "0";
                }

                // Смотрим, какие системы счисления выбраны (с использованием обычных условий)
                string firstBaseStr = "Десятичная";
                if (comboBox1.SelectedItem != null)
                {
                    firstBaseStr = comboBox1.SelectedItem.ToString();
                }

                string secondBaseStr = "Десятичная";
                if (comboBox2.SelectedItem != null)
                {
                    secondBaseStr = comboBox2.SelectedItem.ToString();
                }

                string resultBaseStr = "Десятичная";
                if (comboBox3.SelectedItem != null)
                {
                    resultBaseStr = comboBox3.SelectedItem.ToString();
                }

                int firstBase = NumberBaseOperations.GetBase(firstBaseStr);
                int secondBase = NumberBaseOperations.GetBase(secondBaseStr);
                int resultBase = NumberBaseOperations.GetBase(resultBaseStr);

                // Проверяем, что введенные числа корректны для своих систем счисления
                bool firstValid = NumberBaseOperations.IsValidInput(firstInput, firstBase);
                bool secondValid = NumberBaseOperations.IsValidInput(secondInput, secondBase);

                if (!firstValid || !secondValid)
                {
                    txtResult.Text = "Неверный ввод!";
                    return;
                }

                // Преобразуем числа в десятичные
                int firstNumber = NumberBaseOperations.ConvertToDecimal(firstInput, firstBase);
                int secondNumber = NumberBaseOperations.ConvertToDecimal(secondInput, secondBase);

                // Выполняем выбранную операцию
                string operation = cmbOperation.Text;
                string result = NumberBaseOperations.PerformOperation(firstNumber, secondNumber, operation);


                // Преобразуем результат обратно в нужную систему счисления
                int resultInt = int.Parse(result); // Преобразуем результат операции в число
                string resultStr = NumberBaseOperations.ConvertFromDecimal(resultInt, resultBase); // Преобразуем в нужную систему

                txtResult.Text = resultStr; // Выводим результат в текстовое поле
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
