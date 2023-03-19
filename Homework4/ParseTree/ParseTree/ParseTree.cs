namespace ParseTree;

using System.Collections.Generic;

public class ParseTree
{
    private IOperandNode root;

    public ParseTree(string expression)
    {
        IOperandNode ParseExpression(string expression, ref int currentIndex)
        {
            if (expression[currentIndex] != '(')
            {
                throw new ArgumentException("Paranthesis placement error");
            }

            ++currentIndex;
            var operationSign = expression[currentIndex];
            if (!ParseTreeUtils.IsOperationSign(operationSign))
            {
                throw new ArgumentException("Operation placement error");
            }

            ++currentIndex;

            if (expression[currentIndex] != ' ')
            {
                throw new ArgumentException("Whitespace placement error");
            }

            return CreateOperation(expression, ref currentIndex, operationSign);
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
            if (expression[currentIndex] == '(')
            {
                return ParseExpression(expression, ref currentIndex);
            }
            else
            {
                var stringNumber = new System.Text.StringBuilder();

                while (currentIndex != ' ')
                {
                    stringNumber.Append(expression[currentIndex]);
                    ++currentIndex;
                }

                int intNumber;
                if (int.TryParse(stringNumber.ToString(), out intNumber))
                {
                    throw new ArgumentException("Expression contains not number neither another operation operand.");
                }

                ++currentIndex;

                return new NumberOperand(intNumber);
            }
        }

        if (!ParseTreeUtils.IsParanthesisBalanced(expression)
            || !expression.Any((x) => x == '('))
        {
            throw new ArgumentException("Paranthesis placement error");
        }

        var currentIndex = 0;

        root = ParseExpression(expression, ref currentIndex);
    }
}

