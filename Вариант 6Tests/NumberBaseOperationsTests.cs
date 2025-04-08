namespace Вариант_6.Tests
{
    [TestClass()]
    public class NumberBaseOperationsTests
    {
        [TestMethod()]
        public void GetBaseTest()
        {
            Assert.AreEqual(2, NumberBaseOperations.GetBase("Двоичная"));
            Assert.AreEqual(8, NumberBaseOperations.GetBase("Восьмиричная"));
            Assert.AreEqual(10, NumberBaseOperations.GetBase("Десятичная"));
            Assert.AreEqual(16, NumberBaseOperations.GetBase("Шестнадцатиричная"));
            Assert.AreEqual(10, NumberBaseOperations.GetBase("Что-то другое"));
        }

        [TestMethod()]
        public void IsValidInputTest()
        {
            Assert.IsTrue(NumberBaseOperations.IsValidInput("1010", 2));
            Assert.IsFalse(NumberBaseOperations.IsValidInput("102", 2));

            Assert.IsTrue(NumberBaseOperations.IsValidInput("765", 8));
            Assert.IsFalse(NumberBaseOperations.IsValidInput("89", 8));

            Assert.IsTrue(NumberBaseOperations.IsValidInput("1234567890", 10));
            Assert.IsFalse(NumberBaseOperations.IsValidInput("12A", 10));

            Assert.IsTrue(NumberBaseOperations.IsValidInput("1A3F", 16));
            Assert.IsFalse(NumberBaseOperations.IsValidInput("XYZ", 16));
        }

        [TestMethod()]
        public void ConvertToDecimalTest()
        {
            Assert.AreEqual(10, NumberBaseOperations.ConvertToDecimal("1010", 2));
            Assert.AreEqual(15, NumberBaseOperations.ConvertToDecimal("17", 8));
            Assert.AreEqual(255, NumberBaseOperations.ConvertToDecimal("255", 10));
            Assert.AreEqual(255, NumberBaseOperations.ConvertToDecimal("FF", 16));
        }

        [TestMethod()]
        public void ConvertFromDecimalTest()
        {
            Assert.AreEqual("1010", NumberBaseOperations.ConvertFromDecimal(10, 2));
            Assert.AreEqual("17", NumberBaseOperations.ConvertFromDecimal(15, 8));
            Assert.AreEqual("255", NumberBaseOperations.ConvertFromDecimal(255, 10));
            Assert.AreEqual("FF", NumberBaseOperations.ConvertFromDecimal(255, 16));
        }

        [TestMethod()]
        public void PerformOperationTest()
        {
            Assert.AreEqual("8", NumberBaseOperations.PerformOperation(5, 3, "Сложение"));
            Assert.AreEqual("2", NumberBaseOperations.PerformOperation(5, 3, "Вычитание"));
            Assert.AreEqual("15", NumberBaseOperations.PerformOperation(5, 3, "Умножение"));
            Assert.AreEqual("Числа равны", NumberBaseOperations.PerformOperation(5, 5, "Сравнение"));
            Assert.AreEqual("Числа не равны", NumberBaseOperations.PerformOperation(5, 3, "Сравнение"));
            Assert.AreEqual("Операция не выбрана", NumberBaseOperations.PerformOperation(5, 3, "Неизвестно"));
        }
    }
}
