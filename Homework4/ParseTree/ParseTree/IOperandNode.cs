namespace ParseTree;

public interface IOperandNode
{
    int Evaluate();

    void Print();

    string StringInterpretation { get; }
}

