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

            if (inputString == "")
            {
                Console.WriteLine("Empty string can't be transformed");
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

            if (parameters == "")
            {
                Console.WriteLine("Parameters string can't be empty");
                return;
            }

            var stringArray = parameters.Split();

            if (parameters.Length < 2)
            {
                Console.WriteLine("Not enough parameters");
                return;
            }

            if (parameters.Length > 2)
            {
                Console.WriteLine("!!Warning!! Parameters count more than 2, so were used only first two, it's can lead to unexpected result");
            }

            if (!Int32.TryParse(stringArray[1], out var lastIndex))
            {
                Console.WriteLine("Invalid number input");
                return;
            }

            if (lastIndex < 0 || lastIndex > stringArray[0].Length - 1)
            {
                Console.WriteLine("Last index can't be less than zero or more than length of array - 1");
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