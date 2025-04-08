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
            Assert.AreEqual(16, NumberBaseOperations.GetBase("Шеснадцатиричная"));
            Assert.AreEqual(10, NumberBaseOperations.GetBase("Нерпавильная система счисления"));
        }

        [TestMethod()]
        public void IsValidInputTest()
        {
            // Двоичная система
            Assert.IsTrue(NumberBaseOperations.IsValidInput("1010", 2), "Двоичная: 1010 должно быть валидным");
            Assert.IsFalse(NumberBaseOperations.IsValidInput("102", 2), "Двоичная: 102 не должно быть валидным");

            // Восьмиричная система
            Assert.IsTrue(NumberBaseOperations.IsValidInput("765", 8), "Восьмиричная: 765 должно быть валидным");
            Assert.IsFalse(NumberBaseOperations.IsValidInput("899", 8), "Восьмиричная: 899 не должно быть валидным");

            // Десятичная система
            Assert.IsTrue(NumberBaseOperations.IsValidInput("1234567890", 10), "Десятичная: 1234567890 должно быть валидным");
            Assert.IsFalse(NumberBaseOperations.IsValidInput("12A", 10), "Десятичная: 12A не должно быть валидным");

            // Шестнадцатиричная система
            Assert.IsTrue(NumberBaseOperations.IsValidInput("1A3F", 16), "Шестнадцатиричная: 1A3F должно быть валидным");
            Assert.IsFalse(NumberBaseOperations.IsValidInput("XYZ", 16), "Шестнадцатиричная: XYZ не должно быть валидным");
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
        public void PerformOperationTest()
        {
            Assert.AreEqual("8", NumberBaseOperations.PerformOperation(5, 3, "Сложение"));
            Assert.AreEqual("2", NumberBaseOperations.PerformOperation(5, 3, "Вычитание"));
            Assert.AreEqual("15", NumberBaseOperations.PerformOperation(5, 3, "Умножение"));
            Assert.AreEqual("Числа равны", NumberBaseOperations.PerformOperation(5, 5, "Сравнение"));
            Assert.AreEqual("Числа не равны", NumberBaseOperations.PerformOperation(5, 3, "Сравнение"));
            Assert.AreEqual("Операция не выбрана", NumberBaseOperations.PerformOperation(5, 3, " "));
        }
    }
}
