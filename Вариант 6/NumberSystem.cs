public class NumberSystem
{
    // Десятичное представление числа
    public long decimalValue;

    // Система счисления, в которой было введено число
    public int baseSystem;

    // Конструктор, принимающий стро числа и его систему счисления
    public NumberSystem(string number, int baseSystem)
    {
        this.baseSystem = baseSystem;
        number = number.ToUpper(); // Приведение к верхнему регистру для поддержки A-F

        // Проверка на валидность входного числа
        if (IsValidInput(number, this.baseSystem))
        {
            // Преобразование в десятичное значение
            decimalValue = Convert.ToInt64(number, this.baseSystem);
        }
        else
        {
            decimalValue = 0; // Если ввод некорректен, присваиваем 0
        }
    }

    // Метод возвращает основание системы счисления по её названию
    public static int GetBaseFromString(string baseStr)
    {
        switch (baseStr)
        {
            case "Двоичная": 
                return 2;
            case "Восьмиричная": 
                return 8;
            case "Шеснадцатиричная": 
                return 16;
            default: 
                return 10; // По умолчанию десятичная
        }
    }

    // Проверка корректности ввода числа в заданной системе счисления
    public static bool IsValidInput(string number, int baseSystem)
    {
        if (string.IsNullOrEmpty(number))
        {
            return false;
        }

        number = number.ToUpper();

        foreach (char c in number)
        {
            if (baseSystem == 2 && (c != '0' && c != '1'))
                return false;

            if (baseSystem == 8 && (c < '0' || c > '7'))
                return false;

            if (baseSystem == 10 && (c < '0' || c > '9'))
                return false;

            if (baseSystem == 16 && !((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                return false;
        }
        return true;
    }

    // Преобразование числа в строку заданной системы счисления
    public string ToBase(int targetBase)
    {
        if (decimalValue == 0)
        {
            return "0";
        }

        return Convert.ToString(decimalValue, targetBase).ToUpper();
    }

    // Перегрузка оператора сложения
    public static NumberSystem operator +(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue + b.decimalValue).ToString(), 10);
    }

    // Перегрузка оператора вычитания
    public static NumberSystem operator -(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue - b.decimalValue).ToString(), 10);
    }

    // Перегрузка оператора умножения
    public static NumberSystem operator *(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue * b.decimalValue).ToString(), 10);
    }

    // Перегрузка оператора сравнения на равенство
    public static bool operator ==(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue == b.decimalValue;
    }

    // Перегрузка оператора сравнения на неравенство
    public static bool operator !=(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue != b.decimalValue;
    }
}
