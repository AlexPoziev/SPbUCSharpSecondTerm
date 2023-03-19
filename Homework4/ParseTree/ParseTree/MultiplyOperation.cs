namespace Tree;

/// <summary>
/// Class of the multiply operation node.
/// </summary>
public class MultiplyOperation : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplyOperation"/> class.
    /// </summary>
    public MultiplyOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '*')
    {
    }

    /// <inheritdoc />
    public override double Calculate()
    {
        return LeftOperand.Calculate() * RightOperand.Calculate();
    }
}