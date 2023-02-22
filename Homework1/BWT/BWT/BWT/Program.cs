using Algorithms;

Console.WriteLine("""
    Please, Choose one option:
    1 Encode string by BWT
    2 Decode BWT'ed string
    """);

switch (Console.ReadLine())
{
    case "1":
    {
            Console.WriteLine("Please, input string to transform it: ");

            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                Console.WriteLine("Reading Failed");
                return;
            }

            var result = BWT.DirectBWT(inputString);
            Console.WriteLine($"Encoded string: {result.Item1}\nIndex of the last: {result.Item2}");

            break;
    }
    case "2":
    {
            Console.WriteLine("Input string and index of the last character, separated by space: ");

            var parameters = Console.ReadLine();
            if (parameters == null)
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            var stringArray = parameters.Split();            

            if(!Int32.TryParse(stringArray[1], out var lastIndex))
            {
                Console.WriteLine("Invalid number input");
                return;
            }
            
            Console.WriteLine($"Decoded string: {BWT.InverseBWT(stringArray[0], lastIndex)}");

            break;
    }
    default:
    {
            Console.WriteLine("Incorrect number option");
            return;
    }
}