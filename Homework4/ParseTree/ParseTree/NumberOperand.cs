namespace ParseTree;

public class NumberOperand : IOperandNode
{
    public NumberOperand(int value) => Value = value;

    public int Value { get; set; }

    public int Evaluate() => Value;

    public string StringInterpretation => Value.ToString();

    public void Print() => Console.WriteLine(StringInterpretation);
}

