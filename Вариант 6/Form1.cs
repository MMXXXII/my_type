namespace Вариант_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperation.SelectedIndex = 0; 
        }

        // Событие изменения ввода (числа или параметров)
        private void InputChanged(object sender, EventArgs e)
        {
            Calculate(); 
        }

        // Основной метод, выполняющий вычисления
        private void Calculate()
        {
            // Если оба поля пустые — результат 0
            if (string.IsNullOrEmpty(txtFirst.Text) && string.IsNullOrEmpty(txtSecond.Text))
            {
                txtResult.Text = "0";
                return;
            }

            // Получаем числовые системы из ComboBox'ов
            int firstBase = NumberSystem.GetBaseFromString(comboBox1.Text);
            int secondBase = NumberSystem.GetBaseFromString(comboBox2.Text);
            int resultBase = NumberSystem.GetBaseFromString(comboBox3.Text);

            // Если второе поле пустое — переводим только первое
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

            // Аналогично, если первое поле пустое
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

            // Проверяем корректность обоих чисел
            if (!NumberSystem.IsValidInput(txtFirst.Text, firstBase) ||
                !NumberSystem.IsValidInput(txtSecond.Text, secondBase))
            {
                txtResult.Text = "Введена не та цифра";
                return;
            }

            // Создаём объекты чисел
            var num1 = new NumberSystem(txtFirst.Text, firstBase);
            var num2 = new NumberSystem(txtSecond.Text, secondBase);

            // Обработка выбранной операции
            if (cmbOperation.Text == "Сложение")
            {
                NumberSystem result = num1 + num2;
                txtResult.Text = result.ToBase(resultBase);
            }
            else if (cmbOperation.Text == "Вычитание")
            {
                NumberSystem result = num1 - num2;
                txtResult.Text = result.ToBase(resultBase);
            }
            else if (cmbOperation.Text == "Умножение")
            {
                NumberSystem result = num1 * num2;
                txtResult.Text = result.ToBase(resultBase);
            }
            else if (cmbOperation.Text == "Сравнение")
            {
                txtResult.Text = (num1 == num2) ? "Числа равны" : "Числа не равны";
            }
            else
            {
                txtResult.Text = "Выберите операцию"; // На случай, если ничего не выбрано
            }
        }
    }
}
