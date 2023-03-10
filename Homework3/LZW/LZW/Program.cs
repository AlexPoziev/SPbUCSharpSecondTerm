using Trees;

var trie = new Trie();

trie.Add("e", 0);
trie.Add("eb", 1);
trie.Add("ebc", 4);
trie.Add("ebce", 5);

var test = trie.GetAllValuesOfElement("ebc") ?? new int[] { 1, 2 };

foreach (var element in test)
{
    Console.WriteLine(element);
}