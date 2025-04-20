using Microsoft.VisualStudio.TestTools.UnitTesting;
// Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): 2025-04-20 02:08:50
// Current User's Login: MMXXXII

namespace Вариант_6.Tests
{
    [TestClass()]
    public class NumberSystemTests
    {
        [TestMethod()]
        public void GetBaseTest()
        {
            Assert.AreEqual(2, NumberSystem.GetBaseFromString("Двоичная"));
            Assert.AreEqual(8, NumberSystem.GetBaseFromString("Восьмиричная"));
            Assert.AreEqual(10, NumberSystem.GetBaseFromString("Десятичная"));
            Assert.AreEqual(16, NumberSystem.GetBaseFromString("Шеснадцатиричная"));
            Assert.AreEqual(10, NumberSystem.GetBaseFromString("Неправильная система счисления"));
        }

        [TestMethod()]
        public void IsValidInputTest()
        {
            // Двоичная система
            Assert.AreEqual(true, NumberSystem.IsValidInput("1010", 2));
            Assert.AreEqual(false, NumberSystem.IsValidInput("102", 2));

            // Восьмеричная система
            Assert.AreEqual(true, NumberSystem.IsValidInput("765", 8));
            Assert.AreEqual(false, NumberSystem.IsValidInput("899", 8));

            // Десятичная система
            Assert.AreEqual(true, NumberSystem.IsValidInput("1234567890", 10));
            Assert.AreEqual(false, NumberSystem.IsValidInput("12A", 10));

            // Шестнадцатиричная система
            Assert.AreEqual(true, NumberSystem.IsValidInput("1A3F", 16));
            Assert.AreEqual(false, NumberSystem.IsValidInput("XYZ", 16));
        }

        [TestMethod()]
        public void ConvertToDecimalTest()
        {
            Assert.AreEqual(10, NumberSystem.ConvertToDecimal("1010", 2));
            Assert.AreEqual(15, NumberSystem.ConvertToDecimal("17", 8));
            Assert.AreEqual(255, NumberSystem.ConvertToDecimal("255", 10));
            Assert.AreEqual(255, NumberSystem.ConvertToDecimal("FF", 16));
        }

        [TestMethod()]
        public void PerformOperationTest()
        {
            Assert.AreEqual("8", NumberSystem.PerformOperation(5, 3, "Сложение"));
            Assert.AreEqual("2", NumberSystem.PerformOperation(5, 3, "Вычитание"));
            Assert.AreEqual("15", NumberSystem.PerformOperation(5, 3, "Умножение"));
            Assert.AreEqual("Числа равны", NumberSystem.PerformOperation(5, 5, "Сравнение"));
            Assert.AreEqual("Числа не равны", NumberSystem.PerformOperation(5, 3, "Сравнение"));
            Assert.AreEqual("Операция не выбрана", NumberSystem.PerformOperation(5, 3, " "));
        }
    }
}