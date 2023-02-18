Console.WriteLine("Please, input string: ");

var inputString = Console.ReadLine();
if (inputString == null)
{
    Console.WriteLine("Reading Failed");
    return;
}

Console.WriteLine(value: "Choose one option: \n1 Encode string by BWT\n2 Decode BWT'ed string");

switch (Console.ReadLine())
{
    case "1":
        {
            var result = Algorithms.BWT.DirectBWT(inputString);
            Console.WriteLine($"Encoded string: {result.Item1}\nIndex of the last: {result.Item2}");

            break;
        }
    case "2":
        {
            Console.WriteLine("Input index of the last character: ");
            if(!Int32.TryParse(Console.ReadLine(), out var lastIndex))
            {
                Console.WriteLine("Invalid number input");
                return;
            }
            
            Console.WriteLine($"Decoded string: {Algorithms.BWT.InverseBWT(inputString, lastIndex)}");

            break;
        }
    default:
        {
            Console.WriteLine("Incorrect number option");
            return;
        }
}