namespace StackCalculator;

/// <summary>
/// Class for polish postfix expression calculation`.
/// </summary>
public class PostfixCalculator
{
    /// <summary>
    /// Stack that contain values from string to calculate postfix expression.
    /// </summary>
    private readonly IStack stack;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostfixCalculator"/> class.
    /// </summary>
    /// <param name="stack">Object of class which implement IStack.</param>
    /// <exception cref="ArgumentNullException">stack can't get null.</exception>
    public PostfixCalculator(IStack stack)
    {
        if (stack == null)
        {
            throw new ArgumentNullException(nameof(stack), "Can't be null");
        }

        this.stack = stack;
    }

    /// <summary>
    /// Method to calculate "polish" postfix expression.
    /// </summary>
    /// <param name="expression">Non-null postfix expression</param>
    /// <returns>Pair of float final result and bool, if divides to 0 return false, else true</returns>
    /// <exception cref="ArgumentNullException">expression can't get null.</exception>
    /// <exception cref="ArgumentException">Wrong form of prefix expression.</exception>
    public (float, bool) CalculatePostfixExpression(string expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression), "Can't be null");
        }

        if (expression == string.Empty)
        {
            throw new ArgumentException("Expression can't be empty", nameof(expression));
        }

        var expressionElementsArray = expression.Split();

        foreach (var element in expressionElementsArray)
        {
            if (!element.IsOperationSign())
            {
                if (!float.TryParse(element, out float result))
                {
                    throw new ArgumentException("Not number argument in expression", nameof(expression));
                }

                stack.Push(result);
            }
            else
            {
                float firstOperationElement;
                float secondOperationElement;

                try
                {
                    firstOperationElement = stack.Pop();
                    secondOperationElement = stack.Pop();
                }
                catch
                {
                    throw new ArgumentException("Postfix expression done wrong, not enough numbers to complete operation", nameof(expression));
                }

                (var expressionResult, var isValidExpression) = StackCalculatorUtils.PerformOperation(element, secondOperationElement, firstOperationElement);

                if (!isValidExpression)
                {
                    return (0.0F, false);
                }

                stack.Push(expressionResult);
            }
        }

        float finalResult;
        try
        {
            finalResult = stack.Pop();
        }
        catch
        {
            throw new ArgumentException("Postfix expression done wrong, not enough numbers to complete operation", nameof(expression));
        }

        if (!stack.IsEmpty())
        {
            throw new ArgumentException("Postfix expression done wrong, too many numbers", nameof(expression));
        }
        else
        {
            return (finalResult, true);
        }
    }
}