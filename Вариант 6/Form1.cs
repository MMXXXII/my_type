namespace Вариант_6
{
    public partial class Form1 : Form
    {
        // Конструктор формы
        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
        }

        // Обработчик события изменения ввода пользователем (в любом из полей)
        private void InputChanged(object sender, EventArgs e)
        {
            Calculate(); // Пересчитываем результат при изменении входных данных
        }
       
        // Метод, выполняющий все вычисления и обновляющий результат
        private void Calculate()
        {
            try
            {
                // Считывание первого введённого числа, замена пустого ввода на "0"
                string firstInput = string.IsNullOrWhiteSpace(txtFirst.Text) ? "0" : txtFirst.Text;

                // Считывание второго введённого числа, замена пустого ввода на "0"
                string secondInput = string.IsNullOrWhiteSpace(txtSecond.Text) ? "0" : txtSecond.Text;

                // Получаем выбранные системы счисления из выпадающих списков
                NumberBase firstBase = GetSelectedBase(comboBox1);
                NumberBase secondBase = GetSelectedBase(comboBox2);
                NumberBase resultBase = GetSelectedBase(comboBox3);

                // Проверка корректности ввода для обеих систем счисления
                bool firstValid = NumberBaseOperations.IsValidInput(firstInput, (int)firstBase);
                bool secondValid = NumberBaseOperations.IsValidInput(secondInput, (int)secondBase);

                if (!firstValid || !secondValid)
                {
                    txtResult.Text = "Неверный ввод!";
                    return;
                }

                // Преобразуем оба числа в десятичную систему
                int firstNumber = NumberBaseOperations.ConvertToDecimal(firstInput, firstBase);
                int secondNumber = NumberBaseOperations.ConvertToDecimal(secondInput, secondBase);

                // Получаем выбранную пользователем операцию (арифметика или сравнение)
                string operation = cmbOperation.Text;

                // Выполняем операцию и получаем результат в строковом виде
                string result = NumberBaseOperations.PerformOperation(firstNumber, secondNumber, operation);

                // Обработка случаев сравнения и деления на ноль — их не нужно конвертировать в другую систему
                if (operation == "Сравнение" || result == "Деление на ноль")
                {
                    txtResult.Text = result;
                    return;
                }

                // Преобразуем результат обратно в нужную систему счисления
                int resultInt = int.Parse(result);
                string resultStr = NumberBaseOperations.ConvertFromDecimal(resultInt, resultBase);

                // Выводим результат в соответствующее текстовое поле
                txtResult.Text = resultStr;
            }
            catch (FormatException)
            {
                // Обработка ошибки преобразования формата
                txtResult.Text = "Ошибка ввода";
            }
            catch (OverflowException)
            {
                // Обработка слишком большого числа
                txtResult.Text = "Слишком большое число";
            }
            catch (Exception)
            {
                // Общая обработка любых других исключений
                txtResult.Text = "Непредвиденная ошибка";
            }
        }

        // Метод для определения системы счисления на основе выбранного значения в ComboBox
        private NumberBase GetSelectedBase(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                // Сопоставление строк с элементами перечисления NumberBase
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Двоичная":
                        return NumberBase.Binary;
                    case "Восьмиричная":
                        return NumberBase.Octal;
                    case "Десятичная":
                        return NumberBase.Decimal;
                    case "Шеснадцатиричная":
                        return NumberBase.Hexadecimal;
                    default:
                        return NumberBase.Decimal; // По умолчанию — десятичная
                }
            }

            return NumberBase.Decimal; // Возврат десятичной системы, если ничего не выбрано
        }
    }
}
