using StackCalculator;

var stack = new StackList();

var test = new PostfixCalculator(stack);

(var first, var second) = test.CalculatePostfixExpression("");

Console.WriteLine($"{first}, {second}");