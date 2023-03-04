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
    public void CorrectPostfixExpressionTest(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 - +";
        var expectedValue = 2F;

        (var actualValue, var actualIsExecuted) = postfixCalculator.CalculatePostfixExpression(expression);

        Assert.That(actualIsExecuted && Math.Abs(expectedValue - actualValue) < delta);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void IncorrectSignsCountPostfixExpressionTest(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 -";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void IncorrectNumbersCountPostfixExpressionTest(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 4 - + 5";

        Assert.Throws<ArgumentException>(() => postfixCalculator.CalculatePostfixExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void IncorrectZeroDivideExpressionTest(PostfixCalculator postfixCalculator)
    {
        var expression = "1 2 + 3 0 / +";

        Assert.That(!postfixCalculator.CalculatePostfixExpression(expression).Item2);
    }
}