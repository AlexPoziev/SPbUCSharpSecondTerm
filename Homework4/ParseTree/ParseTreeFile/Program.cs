using Tree;

Console.WriteLine("Input path to file with expression: ");
var filePath = Console.ReadLine();

if (!File.Exists(filePath))
{
    Console.WriteLine("File doesn't exist");
    return;
}

string expression = File.ReadAllText(filePath);

ParseTree parseTree;
try
{
    parseTree = new ParseTree(expression);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return;
}

double result;
try
{
    result = parseTree.Calculate();
}
catch (DivideByZeroException)
{
    Console.WriteLine("Expression contains dividing by 0");
    return;
}
Console.WriteLine($"Calculated value of the ParseTree: {result}");


Console.WriteLine("Parse Tree: ");
parseTree.Print();