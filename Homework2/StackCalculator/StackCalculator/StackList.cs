namespace StackCalculator;

/// <summary>
/// Class that implement stack by list and interface IStack
/// </summary>
/// <typeparam name="T">Generic type</typeparam>
public class StackList<T> : IStack<T>
{
    /// <summary>
    /// List that implement stack
    /// </summary>
    private readonly List<T> stack = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="StackList{T}"/> class.
    /// </summary>
    public StackList() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackList{T}"/> class.
    /// Works only with objects that implement IEnumerable
    /// </summary>
    public StackList(params T[] objects)
    {
        foreach (var item in objects)
        {
            Push(item);
        }
    }

    /// <inheritdoc />
    public void Push(T newElement)
    {
        stack.Insert(0, newElement);
    }

    /// <inheritdoc />
    public bool IsEmpty()
        => !stack.Any();

    /// <inheritdoc />
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack");
        }

        var temp = stack[0];

        stack.RemoveAt(0);

        return temp;
    }
}
