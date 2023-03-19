namespace ParseTree;

public class MinusOperation : Operation
{
    public MinusOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '-')
    {
    }

    public override int Evaluate()
    {
        return LeftOperand.Evaluate() - RightOperand.Evaluate();
    }
}

