using Trees;

Console.WriteLine("It's programm to work with Trie structure");

var isCycle = true;
var trie = new Trie();

while (isCycle)
{
    Console.WriteLine("""

        Choose one of actions:
        0 - Exit
        1 - Add element in Trie
        2 - Remove element from Trie
        3 - Check does Trie contain element
        4 - Get Trie size
        5 - Get number of elements with prefix

        """);

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            isCycle = false;
            break;

        case "1":
        {
            Console.WriteLine("\nPlease, input word to add it into Trie: ");

            var word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            var isSuccsessful = trie.Add(word);

            Console.WriteLine(isSuccsessful ? "Element added" : "Element already exists");

            break;
        }

        case "2":
        {
            Console.WriteLine("\nPlease, input word to remove it from Trie: ");

            var word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            if (word == string.Empty)
            {
                Console.WriteLine("Can't to remove empty string from the Trie");
                break;
            }

            var isSuccsessful = trie.Remove(word);

            Console.WriteLine(isSuccsessful ? "Element removed" : "Element doesn't exist");

            break;
        }

        case "3":
        {
            Console.WriteLine("\nPlease, input word to check does it contained in the Trie: ");

            var word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            Console.WriteLine(trie.Contains(word) ? "Trie contains that element" : "Trie doesn't contain it");

            break;
        }

        case "4":
        {
            Console.WriteLine($"Trie size: {trie.Size}");

            break;
        }

        case "5":
        {
            Console.WriteLine("\nPlease, input prefix to get count of words which start with it: ");

            var prefix = Console.ReadLine();
            if (prefix == null)
            {
                Console.WriteLine("Prefix can't be null");
                break;
            }

            Console.WriteLine($"\nCount of Elements with prefix in trie: {trie.HowManyStartsWithPrefix(prefix)}");

            break;
        }

        default:
            Console.WriteLine("\nIncorrect choose number.");
            break;
    }
}