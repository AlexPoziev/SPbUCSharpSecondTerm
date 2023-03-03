﻿namespace StackCalculator;

/// <summary>
/// Class that implement stack by list and interface IStack
/// </summary>
/// <typeparam name="T">Generic type</typeparam>
public class StackList: IStack
{
    /// <summary>
    /// List that implement stack
    /// </summary>
    private readonly List<float> stack = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="StackList{T}"/> class.
    /// </summary>
    public StackList() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackList{T}"/> class.
    /// </summary>
    public StackList(params float[] objects)
    {
        foreach (var item in objects)
        {
            Push(item);
        }
    }

    /// <inheritdoc />
    public void Push(float newElement)
    {
        stack.Insert(0, newElement);
    }

    /// <inheritdoc />
    public bool IsEmpty()
        => !stack.Any();

    /// <inheritdoc />
    public float Pop()
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
