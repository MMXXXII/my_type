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
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                var firstLength = new Length(firstValue, MeasureType.m);
                var secondLength = new Length(secondValue, MeasureType.m);

                var sumLength = firstLength + secondLength;

                txtResult.Text = sumLength.Verbose();
            }
            catch (FormatException)
            {
                // если тип преобразовать не смогли
            }
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            // старый код убрали, вставили вызов новой функции
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            // старый код убрали, вставили вызов новой функции
            Calculate();
        }
    }
}
