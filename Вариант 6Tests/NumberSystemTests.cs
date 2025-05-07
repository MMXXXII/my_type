
namespace Вариант_6.Tests
{
    [TestClass()]
    public class NumberSystemTests
    {

        [TestMethod()]
        public void IsValidInputTest2()
        {
            // Двоичная система
            Assert.IsTrue(NumberSystem.IsValidInput("1010", 2));


        }

        [TestMethod()]
        public void IsValidInputTest8()
        {
            // Восьмеричная система
            Assert.IsTrue(NumberSystem.IsValidInput("765", 8));

        }

        [TestMethod()]
        public void IsValidInputTest10()
        {
            // Десятичная система
            Assert.IsTrue(NumberSystem.IsValidInput("1234567890", 10));

        }

        [TestMethod()]
        public void IsValidInputTest16()
        {
            // Шестнадцатиричная система
            Assert.IsTrue(NumberSystem.IsValidInput("1A3F", 16));

        }

        [TestMethod()]
        public void IsValidInputTestEmpty()
        {
            // Пустая строка
            Assert.IsFalse(NumberSystem.IsValidInput("", 10));

        }


        [TestMethod()]
        public void ConversionTest2()
        {
            // Тестируем конструктор и преобразования
            var binary = new NumberSystem("1010", 2);
            Assert.AreEqual("1010", binary.ToBase(2));

        }

        [TestMethod()]
        public void ConversionTest8()
        {
            // Тестируем конструктор и преобразования
            var binary = new NumberSystem("1010", 2);
            Assert.AreEqual("12", binary.ToBase(8));


        }

        [TestMethod()]
        public void ConversionTest10()
        {
            // Тестируем конструктор и преобразования
            var binary = new NumberSystem("1010", 2);
            Assert.AreEqual("10", binary.ToBase(10));

        }

        [TestMethod()]
        public void ConversionTest16()
        {
            // Тестируем конструктор и преобразования
            var binary = new NumberSystem("1010", 2);
            Assert.AreEqual("A", binary.ToBase(16));

        }


        [TestMethod()]
        public void ArithmeticOperationsTestPlus()
        {
            var num1 = new NumberSystem("10", 10); // 10
            var num2 = new NumberSystem("5", 10);  // 5

            // Сложение
            var sum = num1 + num2;
            Assert.AreEqual("15", sum.ToBase(10));

        }

        [TestMethod()]
        public void ArithmeticOperationsTestMinus()
        {
            var num1 = new NumberSystem("10", 10); // 10
            var num2 = new NumberSystem("5", 10);  // 5


            // Вычитание
            var diff = num1 - num2;
            Assert.AreEqual("5", diff.ToBase(10));

        }

        [TestMethod()]
        public void InvalidInputTestError1()
        {
            // Проверка обработки некорректного ввода
            var invalidBinary = new NumberSystem("2", 2);
            Assert.AreEqual("0", invalidBinary.ToBase(10));
        }

        [TestMethod()]
        public void InvalidInputTestError2()
        {

            var invalidHex = new NumberSystem("XYZ", 16);
            Assert.AreEqual("0", invalidHex.ToBase(10));

        }

        [TestMethod()]
        public void InvalidInputTestError3()
        {
            var emptyString = new NumberSystem("", 10);
            Assert.AreEqual("0", emptyString.ToBase(10));
        }
    }
}