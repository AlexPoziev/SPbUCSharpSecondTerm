namespace StackCalculator;

/// <summary>
/// Interface for stack implementations
/// </summary>
public interface IStack<T>
{
    /// <summary>
    /// Add new element in stack
    /// </summary>
    /// <param name="newElement">New element that will be added to stack</param>
    void Push(T newElement);

    /// <summary>
    /// Take first element from stack (by rule: first in -- first out)
    /// If try to Pop() empty Stack -- throw 
    /// </summary>
    /// <returns>First element from stack</returns>
    T Pop();

    /// <summary>
    /// Method to check is Stack empty
    /// </summary>
    /// <returns>true -- stack is empty And false -- stack isn't empty</returns>
    bool IsEmpty();
}

