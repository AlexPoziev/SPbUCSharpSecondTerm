namespace ParseTreeTest;

using Tree;

public class Tests
{
    private double delta = 0.000001;

    [Test]
    public void ParseTreeOfSimpleExpressionMethodsShouldReturnExpectedResult()
    {
        const string expression = "(* (+ 1 1) 2)";
        var expectedCalculateResult = 4.0;

        var tree = new ParseTree(expression);

        Assert.That(Math.Abs(tree.Calculate() - expectedCalculateResult) < delta
            && tree.StringInterpretation == expression);
    }

    [Test]
    public void ParseTreeOfComplicatedExpressionMethodsShouldReturnExpectedResult()
    {
        const string expression = "(* (+ (/ -14 2) (- 12 3)) (- 22 -2))";
        var expectedCalculateResult = 48.0;

        var tree = new ParseTree(expression);

        Assert.That(Math.Abs(tree.Calculate() - expectedCalculateResult) < delta
            && tree.StringInterpretation == expression);
    }

    [TestCase("* (+ 1 1) 2")]
    [TestCase("(* + 1 1 2)")]
    public void ExpressionWithoutParenthesisShouldThrowArgumentException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void ExpressionWithNotNumberValueShouldThrowArgumentException()
    {
        const string expression = "(* (+ ff 1) 2)";

        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void ExpressionWithNotSignInStartShouldThrowArgumentException()
    {
        const string expression = "(* ($ 1 1) 2)";

        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void ExpressionWithoutClosingParenthesisShouldThrowArgumentException()
    {
        const string expression = "(* (+ 1 1 2)";

        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void ExpressionWithoutWhiteSpaceAfterClosingParenthesisShouldThrowArgumentException()
    {
        const string expression = "(* (+ 1 1)2)";

        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase("(*")]
    [TestCase("(* (")]
    [TestCase("(* (+1 1")]
    [TestCase("(* (+1 ")]
    [TestCase("(* (+")]
    public void NotFullExpressionCreateShouldThrowArgumentException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void ExplicitDivideByZeroShouldThrowSameNameException()
    {
        const string expression = "(* (/ 1 0) 2)";

        var tree = new ParseTree(expression);

        Assert.Throws<DivideByZeroException>(() => tree.Calculate());
    }

    [Test]
    public void ImplicitDivideByZeroShouldThrowSameNameException()
    {
        const string expression = "(/ (/ 1 1) (- 1 1))";

        var tree = new ParseTree(expression);

        Assert.Throws<DivideByZeroException>(() => tree.Calculate());
    }
}
