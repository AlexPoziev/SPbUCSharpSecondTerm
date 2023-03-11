using Trees;
using Algorithms;
using System.Linq;

//var trie = new Trie();

//trie.Add("e", 0);
//trie.Add("eb", 1);
//trie.Add("ebc", 4);
//trie.Add("ebce", 5);

//var test = trie.GetAllValuesOfElement("ebc") ?? new int[] { 1, 2 };

//foreach (var element in test)
//{
//    Console.WriteLine(element);
//}

var filePath = args[0];
var useKey = args[1];

var lastElementIndex = 0;
var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.')) + ".zipped";
string fileContent = File.ReadAllText(filePath);
File.Create(newFilePath).Close();

(fileContent, var result) = BWT.DirectBWT(fileContent);

File.WriteAllText(newFilePath, fileContent + $"${result}");