public class NumberSystem
{
    public long decimalValue;
    public int baseSystem;

    public NumberSystem(string number, int baseSystem)
    {
        this.baseSystem = baseSystem;
        number = number.ToUpper();

        if (IsValidInput(number, this.baseSystem))
        {
            decimalValue = Convert.ToInt64(number, this.baseSystem);
        }
        else
        {
            decimalValue = 0;
        }
    }

    // Статический метод для получения системы счисления из строки
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
                return 10;
        }
    }

    public static bool IsValidInput(string number, int baseSystem)
    {
        if (string.IsNullOrEmpty(number))
        {
            return false;
        }

        number = number.ToUpper();
        foreach (char c in number)
        {
            if (baseSystem == 2)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            else if (baseSystem == 8)
            {
                if (c < '0' || c > '7')
                {
                    return false;
                }
            }
            else if (baseSystem == 10)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            else if (baseSystem == 16)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public string ToBase(int targetBase)
    {
        if (decimalValue == 0)
        {
            return "0";
        }

        return Convert.ToString(decimalValue, targetBase).ToUpper();
    }

    public static NumberSystem operator +(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue + b.decimalValue).ToString(), 10);
    }

    public static NumberSystem operator -(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue - b.decimalValue).ToString(), 10);
    }

    public static NumberSystem operator *(NumberSystem a, NumberSystem b)
    {
        return new NumberSystem((a.decimalValue * b.decimalValue).ToString(), 10);
    }

    public static bool operator ==(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue == b.decimalValue;
    }

    public static bool operator !=(NumberSystem a, NumberSystem b)
    {
        return a.decimalValue != b.decimalValue;
    }

    public override bool Equals(object obj)
    {
        if (obj is NumberSystem other)
        {
            return this.decimalValue == other.decimalValue;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return decimalValue.GetHashCode();
    }
}