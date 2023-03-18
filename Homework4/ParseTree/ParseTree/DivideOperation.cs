namespace ParseTree;

public class DivideOperation : Operation
{
    public DivideOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '/')
    {
    }

    public override int Evaluate()
    {
        int rightEvaluateResult = RightOperand.Evaluate();
        if (rightEvaluateResult == 0)
        {
            throw new InvalidOperationException("Can't to divide by zero");
        }

        return LeftOperand.Evaluate() + rightEvaluateResult;
    }
}

