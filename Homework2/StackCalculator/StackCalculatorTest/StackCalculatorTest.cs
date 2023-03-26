namespace StackCalculatorTest;

using StackCalculator;

public class StackCalculatorTest
{
    private readonly float delta = 0.00001F;

    private static IEnumerable<TestCaseData> StackCalculator()
    {
        yield return new TestCaseData(new PostfixCalculator(new StackArray()));
        yield return new TestCaseData(new PostfixCalculator(new StackList()));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CorrectPostfixExpressionShouldReturnTrueAndExpectedValue(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 - +";
        var expectedValue = 2F;

        (var actualValue, var actualIsExecuted) = postfixCalculator.CalculatePostfixExpression(expression);

        Assert.That(actualIsExecuted && Math.Abs(expectedValue - actualValue) < delta);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CorrectRealNumberPostfixExpressionShouldReturnTrueAndExpectedValue(PostfixCalculator postfixCalculator)
    {
        var expression = "1.5 2.5 + 3.36 5.86 - +";
        var expectedValue = 1.5F;

        (var actualValue, var actualIsExecuted) = postfixCalculator.CalculatePostfixExpression(expression);

        Assert.That(actualIsExecuted && Math.Abs(expectedValue - actualValue) < delta);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CorrectRealNumberPostfixExpressionWithMultiplicationAndDivisionShouldReturnTrueAndExpectedValue(PostfixCalculator postfixCalculator)
    {
        var expression = "1.5 2.5 * 3.36 5.86 / *";
        var expectedValue = 2.15017F;

        (var actualValue, var actualIsExecuted) = postfixCalculator.CalculatePostfixExpression(expression);

        Assert.That(actualIsExecuted && Math.Abs(expectedValue - actualValue) < delta);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void ExpressionWithIncorrectNumberOfSignsShouldThrowsException(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 -";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void RealNumberExpressionWithIncorrectNumberOfSignsShouldThrowsException(PostfixCalculator postfixCalculator)
    {
        var expression = "1.5 2.1 + 3 4.13 -";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void ExpressionWithIncorrectCountOfNumbersShouldThrowsException(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 - + 5";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void ExpressionWithIncorrectCountOfRealNumbersShouldThrowsException(PostfixCalculator postfixCalculator)
    {
        var expression = "1.001 25.11 + 35.1 4 - + 5";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void IncorrectZeroDivideExpressionShouldReturnFalse(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 0 / +";

        Assert.That(!postfixCalculator.CalculatePostfixExpression(expression).Item2);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void IncorrectRealNumberZeroDivideExpressionShouldReturnFalse(PostfixCalculator postfixCalculator)
    {
        var expression = "1.5 2.12 + 3 0.0 / +";

        Assert.That(!postfixCalculator.CalculatePostfixExpression(expression).Item2);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void ImplicitIncorrectRealNumberZeroDivideExpressionShouldReturnFalse(PostfixCalculator postfixCalculator)
    {
        var expression = "1 1.13 2.12 + 2.75 6 - + /";

        Assert.That(!postfixCalculator.CalculatePostfixExpression(expression).Item2);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void NullArgumentShouldThrowsArgumentNullException(PostfixCalculator postfixCalculator)
    {
        string? expression = null;

        Assert.Throws<ArgumentNullException>(() => postfixCalculator.CalculatePostfixExpression(expression!));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void EmptyStringArgumentShouldThrowsArgumentException(PostfixCalculator postfixCalculator)
    {
        string expression = string.Empty;

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }


}