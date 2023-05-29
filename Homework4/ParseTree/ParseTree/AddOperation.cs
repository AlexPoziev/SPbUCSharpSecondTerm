namespace Tree;

/// <summary>
/// Class performs add operation node.
/// </summary>
public class AddOperation : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddOperation"/> class.
    /// </summary>
    public AddOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '+')
    {
    }

    /// <inheritdoc />
    public override double Calculate()
    {
        return LeftOperand.Calculate() + RightOperand.Calculate();
    }
}