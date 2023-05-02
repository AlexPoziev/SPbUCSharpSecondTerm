namespace Tree;

/// <summary>
/// Abstract Class representing an operation node.
/// </summary>
public abstract class Operation : IOperandNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Operation"/> class.
    /// </summary>
    protected Operation(IOperandNode firstOperand, IOperandNode secondOperand, char operationSign)
    {
        LeftOperand = firstOperand ?? throw new ArgumentNullException(nameof(firstOperand));
        RightOperand = secondOperand ?? throw new ArgumentNullException(nameof(secondOperand));
        OperationSign = operationSign;
    }

    /// <summary>
    /// Gets string form of operation.
    /// </summary>
    public string StringInterpretation
            => $"({OperationSign} {LeftOperand.StringInterpretation} {RightOperand.StringInterpretation})";

    /// <summary>
    /// Gets or sets first operation's operand.
    /// </summary>
    public IOperandNode LeftOperand { get; }

    /// <summary>
    /// Gets or sets second operation's operand.
    /// </summary>
    public IOperandNode RightOperand { get; }

    /// <summary>
    /// Gets or sets arithmetical sign of the operation.
    /// </summary>
    public char OperationSign { get; }

    /// <summary>
    /// Method that calculate operation result.
    /// </summary>
    /// <returns>result of calculation in the form: "(OperationSign FirstOperand SecondOperand)".</returns
    /// <exception cref="DivideByZeroException"></exception>
    public abstract double Calculate();

    /// <summary>
    /// Print operation in the form: "(OperationSign FirstOperand SecondOperand)".
    /// </summary>
    public void Print() => Console.WriteLine(StringInterpretation);
}
