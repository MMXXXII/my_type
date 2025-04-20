public class NumberSystem
{
    private long decimalValue;
    private int baseSystem;

    public enum NumberBase
    {
        Binary = 2,
        Octal = 8,
        Decimal = 10,
        Hexadecimal = 16
    }

    public NumberSystem(string number, NumberBase baseSystem)
    {
        this.baseSystem = (int)baseSystem;
        number = number.ToUpper();
        if (IsValidInput(number, this.baseSystem))
        {
            this.decimalValue = ConvertToDecimal(number, this.baseSystem);
        }
        else
        {
            this.decimalValue = 0;
        }
    }

    public static int GetBaseFromString(string baseStr)
    {
        if (baseStr == "Двоичная")
            return 2;
        else if (baseStr == "Восьмиричная")
            return 8;
        else if (baseStr == "Десятичная")
            return 10;
        else if (baseStr == "Шеснадцатиричная")
            return 16;
        else
            return 10;
    }

    public static bool IsValidInput(string number, int baseSystem)
    {
        number = number.ToUpper();
        foreach (char c in number)
        {
            switch (baseSystem)
            {
                case 2:
                    if (c != '0' && c != '1')
                        return false;
                    break;
                case 8:
                    if (c < '0' || c > '7')
                        return false;
                    break;
                case 10:
                    if (c < '0' || c > '9')
                        return false;
                    break;
                case 16:
                    if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                        return false;
                    break;
                default:
                    return false;
            }
        }
        return number.Length > 0;
    }

    public static long ConvertToDecimal(string number, int fromBase)
    {
        if (!IsValidInput(number, fromBase))
            return 0;
        return Convert.ToInt64(number, fromBase);
    }

    public static string PerformOperation(long num1, long num2, string operation)
    {
        switch (operation)
        {
            case "Сложение":
                return (num1 + num2).ToString();
            case "Вычитание":
                return (num1 - num2).ToString();
            case "Умножение":
                return (num1 * num2).ToString();
            case "Сравнение":
                return num1 == num2 ? "Числа равны" : "Числа не равны";
            default:
                return "Операция не выбрана";
        }
    }

    public string ToBase(NumberBase targetBase)
    {
        if (decimalValue == 0)
            return "0";
        return Convert.ToString(decimalValue, (int)targetBase).ToUpper();
    }

    // Операторы
    public static NumberSystem operator +(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue + b.decimalValue).ToString(), NumberBase.Decimal);
    }

    public static NumberSystem operator -(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue - b.decimalValue).ToString(), NumberBase.Decimal);
    }

    public static NumberSystem operator *(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue * b.decimalValue).ToString(), NumberBase.Decimal);
    }

    public static bool operator ==(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue == b.decimalValue;
    }

    public static bool operator !=(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue != b.decimalValue;
    }
}