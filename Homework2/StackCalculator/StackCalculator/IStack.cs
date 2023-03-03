namespace StackCalculator;

/// <summary>
/// Interface for stack implementations
/// </summary>
public interface IStack<T>
{
    /// <summary>
    /// Add new object to Stack
    /// </summary>
    /// <param name="newElement">New element that will be added to stack</param>
    void Push(T newElement);

    /// <summary>
    /// Remove and return first object from Stack (by rule: first in -- first out)
    /// </summary>
    /// <returns>First element from stack</returns>
    /// <exception cref="InvalidOperationException">Pop from empty Stack</exception>
    T Pop();

    /// <summary>
    /// Method to check is Stack empty
    /// </summary>
    /// <returns>true -- stack is empty And false -- stack isn't empty</returns>
    bool IsEmpty();
}

