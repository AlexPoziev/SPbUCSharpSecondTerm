namespace CalculatorTests;

using System.Linq.Expressions;
using Calculator;

public class Tests
{
    readonly CalculationCore calculator = new CalculationCore();

    private void AddExpressionInCalculator(string expression)
    {
        foreach (var element in expression)
        {
            calculator.AddElement(element);
        }
    }

    [TearDown]
    public void Teardown()
    {
        calculator.ClearCalculator();
    }

    [Test]
    public void CalculatorWithoutChangesShouldDisplayZero()
    {
        var expectedResult = "0";

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CalculatorAfterAddNumberShouldDisplay()
    {
        var expectedResult = "5";

        calculator.AddElement('5');

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1+1+", "2")]
    [TestCase("6/3/1=", "2")]
    [TestCase("2*8+", "16")]
    [TestCase("5-10-", "-5")]
    public void BasicIntegersExpressionsCalculationShouldReturnExpectedResult(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1+1+1.5+", "3.5")]
    [TestCase("6/3/4=", "0.5")]
    [TestCase("2*0.125+", "0.25")]
    [TestCase("5-10.5=", "-5.5")]
    [TestCase("5/3=", "1.6666666")]
    public void BasicRealNumberExpressionsCalculationShouldReturnExpectedResult(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TryToAddNotANumberNorASignShouldMakeNoDifference()
    {
        var expectedResult = "5";

        calculator.AddElement('5');
        calculator.AddElement('D');

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TryToDiviveByZeroShouldDisplayError()
    {
        var expectedResult = "Error";
        var expression = "1/0=";

        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1+1====", "5")]
    [TestCase("8/2===", "1")]
    [TestCase("5-3===", "-4")]
    public void EqualitySignsAfterExpressionShouldRepeatLastAction(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1+-1=", "0")]
    [TestCase("8/*/2=", "4")]
    public void SignAfterSignShouldChangeSignOfOperation(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("", "0")]
    [TestCase("10", "-10")]
    [TestCase("10-20-", "10")]
    [TestCase("1/0=", "Error")]
    public void ChangeSignOfNumberShouldPerformExpectedResult(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);
        calculator.ChangeSignOfNumber();

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1.005==", "1.005")]
    [TestCase("8====", "8")]
    public void EqualSignsAfterFirstNumberShouldMakeNoChanges(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }

    [TestCase("1+====", "5")]
    [TestCase("1+-====", "-3")]
    [TestCase("1+/====", "1")]
    public void EqualSignsAfterOperationSignWithoutSecondOperandShouldPerformExpectedResult(string expression, string expectedResult)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculator.DisplayNumber, Is.EqualTo(expectedResult));
    }
}