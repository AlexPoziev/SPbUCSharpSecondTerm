namespace Tree;

/// <summary>
/// Class that performs number operand.
/// </summary>
public class NumberOperand : IOperandNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperand"/> class.
    /// </summary>
    /// <param name="value">operand value.</param>
    public NumberOperand(int value) => Value = value;

    /// <summary>
    /// Gets string in form: "Value".
    /// </summary>
    public string StringInterpretation => Value.ToString();

    /// <summary>
    /// Value of the number operand.
    /// </summary>
    public int Value { get; set; }

    /// <inheritdoc />
    public double Calculate() => Value;

    /// <summary>
    /// Method to print in console text in form: "Value".
    /// </summary>
    public void Print() => Console.WriteLine(StringInterpretation);
}