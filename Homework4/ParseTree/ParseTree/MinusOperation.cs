namespace Tree;

/// <summary>
/// Class of the minus operation node.
/// </summary>
public class MinusOperation : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MinusOperation"/> class.
    /// </summary>
    public MinusOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '-')
    {
    }

    /// <inheritdoc />
    public override double Calculate()
    {
        return LeftOperand.Calculate() - RightOperand.Calculate();
    }
}