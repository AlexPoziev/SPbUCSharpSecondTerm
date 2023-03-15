namespace StackCalculator;

/// <summary>
/// Class that contains utils for work with StackCalculator.
/// </summary>
public static class StackCalculatorUtils
{
    /// <summary>
    /// Method to distinguish operations signs(+, -, *, /) and other strings.
    /// </summary>
    /// <param name="value">String to check is it sign.</param>
    /// <returns>True -- basic arithmetical sign, False -- else.</returns>
    public static bool IsOperationSign(this char value)
            => value == '-' || value == '+' || value == '*' || value == '/';

    /// <summary>
    /// Method to perform operations by it's string perfomance.
    /// </summary>
    /// <param name="operation">Basic arithmetical sign.</param>
    /// <param name="firstNumber">First number of expression.</param>
    /// <param name="secondNumber">Second number of expression.</param>
    /// <returns>Result of expression: <paramref name="firstNumber"/>
    /// <paramref name="operation"/> <paramref name="secondNumber"/>.</returns>
    /// <exception cref="ArgumentNullException">operation can't be null.</exception>
    /// <exception cref="ArgumentException">operation nothing from set (-, +, /, *).</exception>
    public static (float, bool) PerformOperation(char operation, float firstNumber, float secondNumber)
    {

        switch (operation)
        {
            case '+':
                return (firstNumber + secondNumber, true);

            case '-':
                return (firstNumber - secondNumber, true);

            case '*':
                return (firstNumber * secondNumber, true);

            case '/':
            {
                const float delta = 0.000001F;
                return Math.Abs(0.0F - secondNumber) < delta
                    ? (0.0F, false)
                    : (firstNumber / secondNumber, true);
            }

            default:
                throw new ArgumentException("Not operation sign", nameof(operation));
        }
    }
}