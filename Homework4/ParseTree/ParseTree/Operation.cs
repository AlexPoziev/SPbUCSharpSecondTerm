namespace ParseTree;

abstract public class Operation : IOperandNode
{
    public Operation(IOperandNode firstOperand, IOperandNode secondOperand, char value)
    {
        OperationSign = value;
        LeftOperand = firstOperand;
        RightOperand = secondOperand;
    }

    public IOperandNode LeftOperand { get; set; }

    public IOperandNode RightOperand { get; set; }

    public char OperationSign { get; set; }

    public abstract int Evaluate();

    public string StringInterpretation
            => LeftOperand.StringInterpretation + OperationSign.ToString() + RightOperand.StringInterpretation;

    public void Print() => Console.WriteLine(StringInterpretation);
}
