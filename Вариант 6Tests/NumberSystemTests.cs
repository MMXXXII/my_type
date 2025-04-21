
namespace Вариант_6.Tests
{
    [TestClass()]
    public class NumberSystemTests
    {

        [TestMethod()]
        public void IsValidInputTest()
        {
            // Двоичная система
            Assert.IsTrue(NumberSystem.IsValidInput("1010", 2));
            Assert.IsFalse(NumberSystem.IsValidInput("102", 2));

            // Восьмеричная система
            Assert.IsTrue(NumberSystem.IsValidInput("765", 8));
            Assert.IsFalse(NumberSystem.IsValidInput("899", 8));

            // Десятичная система
            Assert.IsTrue(NumberSystem.IsValidInput("1234567890", 10));
            Assert.IsFalse(NumberSystem.IsValidInput("12A", 10));

            // Шестнадцатиричная система
            Assert.IsTrue(NumberSystem.IsValidInput("1A3F", 16));
            Assert.IsFalse(NumberSystem.IsValidInput("XYZ", 16));

            // Пустая строка
            Assert.IsFalse(NumberSystem.IsValidInput("", 10));
            Assert.IsFalse(NumberSystem.IsValidInput(null, 10));
        }

        [TestMethod()]
        public void ConversionTest()
        {
            // Тестируем конструктор и преобразования
            var binary = new NumberSystem("1010", 2);
            Assert.AreEqual("1010", binary.ToBase(2));
            Assert.AreEqual("12", binary.ToBase(8));
            Assert.AreEqual("10", binary.ToBase(10));
            Assert.AreEqual("A", binary.ToBase(16));

        }

        [TestMethod()]
        public void ArithmeticOperationsTest()
        {
            var num1 = new NumberSystem("10", 10); // 10
            var num2 = new NumberSystem("5", 10);  // 5

            // Сложение
            var sum = num1 + num2;
            Assert.AreEqual("15", sum.ToBase(10));

            // Вычитание
            var diff = num1 - num2;
            Assert.AreEqual("5", diff.ToBase(10));

            // Умножение
            var mult = num1 * num2;
            Assert.AreEqual("50", mult.ToBase(10));

            // Проверка в разных системах счисления
            Assert.AreEqual("1111", sum.ToBase(2));
            Assert.AreEqual("17", sum.ToBase(8));
            Assert.AreEqual("F", sum.ToBase(16));
        }

        [TestMethod()]
        public void InvalidInputTest()
        {
            // Проверка обработки некорректного ввода
            var invalidBinary = new NumberSystem("2", 2);
            Assert.AreEqual("0", invalidBinary.ToBase(10));

            var invalidHex = new NumberSystem("XYZ", 16);
            Assert.AreEqual("0", invalidHex.ToBase(10));

            var emptyString = new NumberSystem("", 10);
            Assert.AreEqual("0", emptyString.ToBase(10));
        }
    }
}