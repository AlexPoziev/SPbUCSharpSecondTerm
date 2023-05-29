namespace Tree;

/// <summary>
/// Interface of the node, that performs operation element.
/// </summary>
public interface IOperandNode
{
    /// <summary>
    /// Gets string form of the operand.
    /// </summary>
    string StringInterpretation { get; }

    /// <summary>
    /// Calculate operand value.
    /// </summary>
    /// <returns>fractional result of calculation.</returns>
    double Calculate();

    /// <summary>
    /// Method that performs writing of the operand to Console.
    /// </summary>
    void Print();
}
