namespace Routers;

public static class StringParseUtils
{
    public static int TryGetNumberUntilSign(char sign, ref int currentIndex, string currentString)
    {
        if (currentIndex >= currentString.Length || currentIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(currentIndex));
        }

        var newStringNumber = new System.Text.StringBuilder();

        while (currentIndex < currentString.Length && currentString[currentIndex] != sign)
        {
            newStringNumber.Append(currentString[currentIndex]);
            ++currentIndex;
        }

        if (currentIndex == currentString.Length)
        {
            throw new IncorrectTopologyFormException($"Not enough '{sign}' sign");
        }

        if (!int.TryParse(newStringNumber.ToString(), out var newNumber))
        {
            throw new IncorrectTopologyFormException($"'{newStringNumber}' must to be a number");
        }

        return newNumber;
    }

    public static void IsInRange(string expression, int index)
    {
        if (index > expression.Length || index < 0)
        {
            throw new ArgumentException("String not full");
        }
    }
}

