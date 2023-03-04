namespace StackCalculator;

/// <summary>
/// Class that implement stack by array and interface IStack.
/// </summary>
public class StackArray : IStack
{
    /// <summary>
    /// Index of first element in stack, can't be less than 0.
    /// If array empty, holds -1 value.
    /// </summary>
    private int topIndex = -1;

    /// <summary>
    /// Current size of stack, mutable
    /// Change when stack overflows.
    /// </summary>
    private int currentArraySize = 2;

    /// <summary>
    /// List that implement stack.
    /// </summary>
    private float[] stack;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackArray"/> class.
    /// </summary>
    public StackArray()
    {
        this.stack = new float[this.currentArraySize];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackArray"/> class by multible arguments.
    /// </summary>
    /// <param name="numbers">Mutiple arguments float type.</param>
    public StackArray(params float[] numbers)
    {
        stack = new float[currentArraySize];

        foreach (var number in numbers)
        {
            Push(number);
        }
    }

    /// <summary>
    /// Method to resize stack to size * 2.
    /// Use when stack overflow.
    /// </summary>
    private void ResizeStack()
    {
        currentArraySize *= 2;

        var tempArray = new float[currentArraySize];
        stack.CopyTo(tempArray, 0);

        stack = tempArray;
    }

    /// <inheritdoc />
    public void Push(float newElement)
    {
        ++topIndex;

        if (topIndex == currentArraySize)
        {
            ResizeStack();
        }

        stack[topIndex] = newElement;
    }

    /// <inheritdoc />
    public bool IsEmpty()
        => topIndex == -1;

    /// <inheritdoc />
    public float Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack");
        }

        var temp = stack[topIndex];
        stack[topIndex] = 0;

        --topIndex;

        return temp;
    }
}