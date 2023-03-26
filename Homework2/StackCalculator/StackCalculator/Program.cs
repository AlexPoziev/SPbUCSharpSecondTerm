using StackCalculator;

Console.WriteLine("""
    Please, input polish postfix expression that you want to calculate.

    Elements of expression must be separated by whitespace.
    And it mustn't contain divide on zero.
    Result will be given with two other stack implementation: Array and List

    """);

var expression = Console.ReadLine();
if (expression == null)
{
    Console.WriteLine("Fail reading of expression");
    return;
}

// Stack by array
var arrayStack = new StackArray();
var stackCalculator = new PostfixCalculator(arrayStack);

(var result, var isExecuted) = stackCalculator.CalculatePostfixExpression(expression);
if (!isExecuted)
{
    Console.WriteLine("Postfix expression contains dividing by zero");
    return;
}

Console.WriteLine($"Array Stack result: {result}");

// Stack by list
var listStack = new StackList();
stackCalculator = new PostfixCalculator(listStack);

(result, isExecuted) = stackCalculator.CalculatePostfixExpression(expression);
if (!isExecuted)
{
    Console.WriteLine("Postfix expression contains dividing by zero");
    return;
}

Console.WriteLine($"List Stack result: {result}");