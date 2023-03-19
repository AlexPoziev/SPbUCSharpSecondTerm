namespace ParseTree;

public class AddOperation : Operation
{
    public AddOperation(IOperandNode firstOperand, IOperandNode secondOperand)
        : base(firstOperand, secondOperand, '+')
    {
    }
    
    public override int Evaluate()
    {
        return LeftOperand.Evaluate() + RightOperand.Evaluate();
    }
}

