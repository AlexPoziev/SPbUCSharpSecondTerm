namespace StackCalculatorTest;

using StackCalculator;

public class StackTests
{
    private static IEnumerable<TestCaseData> Stack()
    {
        yield return new TestCaseData(new StackArray());
        yield return new TestCaseData(new StackList());
    }

    [TestCaseSource(nameof(Stack))]
    public void PushAndPopShouldReturnSameValues(IStack stack)
    {
        var random = new Random();
        var inputStackArray = new float[random.Next(50)];
        for (int i = 0; i < inputStackArray.Length; ++i)
        {
            inputStackArray[i] = random.Next();
            stack.Push(inputStackArray[i]);
        }

        var popStackArray = new float[inputStackArray.Length];
        for (int i = 0; i < inputStackArray.Length; ++i)
        {
            popStackArray[inputStackArray.Length - i - 1] = stack.Pop();
        }

        Assert.That(inputStackArray, Is.EqualTo(popStackArray));
    }

    [TestCaseSource(nameof(Stack))]
    public void IsEmptyShouldReturnExpecterValue(IStack stack)
    {
        var isNewStackEmpty = stack.IsEmpty();

        stack.Push(0.0F);

        var isStackWithOneElementEmpty = stack.IsEmpty();

        stack.Pop();

        var isStackWithLastDeletedElementEmpty = stack.IsEmpty();

        Assert.That(isNewStackEmpty && isStackWithLastDeletedElementEmpty && !isStackWithOneElementEmpty);
    }

    [TestCaseSource(nameof(Stack))]
    public void PopEmptyStackShouldThrowsException(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}