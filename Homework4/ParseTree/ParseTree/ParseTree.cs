namespace Tree;

/// <summary>
/// Parse Tree of a mathematical expression class.
/// </summary>
public class ParseTree
{
    private readonly IOperandNode root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// </summary>
    /// <param name="expression">Gets expression in form ( operation operand1 operand2). Operand may to be mathematical expression too.</param>
    /// <exception cref="ArgumentException">Incorrect form of the expression.</exception>
    public ParseTree(string expression)
    {
        IOperandNode ParseExpression(string expression, ref int currentIndex)
        {
            ParseTreeUtils.IsInRange(expression, currentIndex);

            if (expression[currentIndex] != '(')
            {
                throw new ArgumentException("Open Paranthesis placement error");
            }

            ++currentIndex;
            ParseTreeUtils.IsInRange(expression, currentIndex);

            var operationSign = expression[currentIndex];
            if (!ParseTreeUtils.IsOperationSign(operationSign))
            {
                throw new ArgumentException("No Operation sign after paranthesis found");
            }

            ++currentIndex;

            if (currentIndex > expression.Length || expression[currentIndex] != ' ')
            {
                throw new ArgumentException("No Whitespace after operation sign found");
            }

            ++currentIndex;

            var newOperation = CreateOperation(expression, ref currentIndex, operationSign);

            if (currentIndex < expression.Length && expression[currentIndex] != ' ' && expression[currentIndex] != ')')
            {
                throw new ArgumentException("Incorrect symbol after expression found");
            }

            ++currentIndex;

            return newOperation;
        }

        Operation CreateOperation(string expression, ref int currentIndex, char operationsSign) =>
            operationsSign switch
            {
                '+' => new AddOperation(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
                '-' => new MinusOperation(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
                '*' => new MultiplyOperation(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
                '/' => new DivideOperation(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
                _ => throw new ArgumentException("In the arithmetical signs spot contains not sign"),
            };

        IOperandNode CreateOperand(string expression, ref int currentIndex)
        {
            if (currentIndex >= expression.Length)
            {
                throw new ArgumentException("Not enough operands");
            }

            if (expression[currentIndex] == '(')
            {
                return ParseExpression(expression, ref currentIndex);
            }
            else
            {
                if (ParseTreeUtils.IsOperationSign(expression[currentIndex])
                        && (currentIndex + 1 >= expression.Length
                        || !((expression[currentIndex] == '+' || expression[currentIndex] == '-')
                        && char.IsDigit(expression[currentIndex + 1]))))
                {
                    throw new ArgumentException("Begin of the new expression must to start with '(' ");
                }

                var stringNumber = new System.Text.StringBuilder();

                while (expression[currentIndex] != ' ' && expression[currentIndex] != ')')
                {
                    stringNumber.Append(expression[currentIndex]);
                    ++currentIndex;

                    ParseTreeUtils.IsInRange(expression, currentIndex);
                }

                if (!int.TryParse(stringNumber.ToString(), out int intNumber))
                {
                    throw new ArgumentException("The expression contains not a number, nor another expression");
                }

                ++currentIndex;

                return new NumberOperand(intNumber);
            }
        }

        if (!ParseTreeUtils.AreParanthesisBalanced(expression)
                || !expression.Any((x) => x == '('))
        {
            throw new ArgumentException("Parenthesis are incorrectly placed");
        }

        var currentIndex = 0;

        root = ParseExpression(expression, ref currentIndex);
    }

    /// <summary>
    /// Gets new created expression from parse tree in form: "(operation operand1 operand2)".
    /// </summary>
    public string StringInterpretation => root.StringInterpretation;

    /// <summary>
    /// Print to console expression int parse tree in form: "(operation operand1 operand2)".
    /// </summary>
    public void Print() => Console.WriteLine(StringInterpretation);

    /// <summary>
    /// Calculate expression in parse tree.
    /// </summary>
    /// <returns>Result of calculation</returns>
    /// <exception cref="DivideByZeroException">Second operand of divide can't to be 0.</exception>
    public double Calculate() => root.Calculate();
}