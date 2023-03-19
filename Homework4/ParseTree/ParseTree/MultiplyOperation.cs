namespace Tree;

public class MultiplyOperation : Operation
{
    public MultiplyOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '*')
    {
    }

    public override int Evaluate()
    {
        return LeftOperand.Evaluate() * RightOperand.Evaluate();
    }
}

