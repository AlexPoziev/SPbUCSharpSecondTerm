namespace StackCalculator;

/// <summary>
/// Stack, a first-in-first-out container for integer values.
/// only for float type.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Add new object to Stack.
    /// </summary>
    /// <param name="newElement">New element that will be added to stack.</param>
    void Push(float newElement);

    /// <summary>
    /// Remove and return first object from Stack (by rule: first in -- first out).
    /// </summary>
    /// <returns>First element from stack.</returns>
    /// <exception cref="InvalidOperationException">Pop from empty Stack.</exception>
    float Pop();

    /// <summary>
    /// Method to check is Stack empty.
    /// </summary>
    /// <returns>true -- stack is empty And false -- stack isn't empty.</returns>
    bool IsEmpty();
}