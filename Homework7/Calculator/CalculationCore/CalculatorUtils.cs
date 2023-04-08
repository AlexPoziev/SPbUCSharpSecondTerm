namespace Calculator;

public static class CalculatorUtils
{
    public static bool AreFloatsEqual(float firstNumber, float secondNumber)
    {
        var delta = 0.000001f;

        return Math.Abs(firstNumber - secondNumber) < delta;
    }

    public static bool IsOperationSign(char sign)
            => sign == '+' || sign == '-' || sign == '*' || sign == '/' || sign == '%';

    public static float PerformArithmeticalOperation(float firstNumber, float secondNumber, char operation)
    {
        switch (operation)
        {
            case '+':
                return firstNumber + secondNumber;

            case '-':
                return firstNumber - secondNumber;

            case '*':
                return firstNumber * secondNumber;

            case '/':
                if (AreFloatsEqual(0.0f, secondNumber))
                {
                    throw new DivideByZeroException();
                }

                return firstNumber / secondNumber;

            case '%':
                return secondNumber / 100 * firstNumber;

            default:
                throw new ArgumentException("Not operation sign");
        }
    }

    public static string PerformTwoFloatStringsOperation(string firstNumberString, string secondNumberString, char sign)
    {
        if (!float.TryParse(firstNumberString, out var firstNumber))
        {
            throw new ArgumentException();
        }

        if (!float.TryParse(secondNumberString, out var secondNumber))
        {
            throw new ArgumentException();
        }

        return (PerformArithmeticalOperation(firstNumber, secondNumber, sign)).ToString();
    }
}
