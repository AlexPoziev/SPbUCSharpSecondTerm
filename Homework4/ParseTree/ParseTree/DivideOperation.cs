namespace Tree;

/// <summary>
/// Class of the divide operation node.
/// </summary>
public class DivideOperation : Operation
{

    /// <summary>
    /// Initializes a new instance of the <see cref="DivideOperation"/> class.
    /// </summary>
    public DivideOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '/')
    {
    }

    /// <summary>
    /// Calculate divide operation.
    /// </summary>
    /// <returns>Result of calculation.</returns>
    /// <exception cref="InvalidOperationException">SecondOperand can't be 0.</exception>
    public override double Calculate()
    {
        double rightEvaluateResult = RightOperand.Calculate();
        double delta = 0.000001;
        if (Math.Abs(rightEvaluateResult - 0.0) < delta)
        {
            throw new DivideByZeroException();
        }

        return LeftOperand.Calculate() / rightEvaluateResult;
    }
}