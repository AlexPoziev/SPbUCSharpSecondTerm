using Trees;
using Algorithms;
using System.Linq;
using LZW;

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


// BWT FROM FILE 
var filePath = args[0];
var useKey = args[1];

var newFilePath = filePath + ".zipped";

//string fileContent = Convert.ToBase64String(File.ReadAllBytes(filePath));

//(fileContent, var lastElementIndex) = BWT.DirectBWT(fileContent);

//File.WriteAllText(filePath, fileContent + $"{lastElementIndex}");

//File.Create(newFilePath).Close();

//FileInfo first = new FileInfo(filePath);
//double firstSize = first.Length;

//var encoder = new LZWEncode();
//encoder.Encode(filePath, newFilePath);

//FileInfo second = new FileInfo(newFilePath);
//double secondSize = second.Length;

//var testSecond = File.ReadAllBytes(newFilePath);

//var decoder = new LZWDecode();

//decoder.Decode(newFilePath, filePath);

//double check = secondSize / firstSize;

//byte[] arrayOfBytes = File.ReadAllBytes(filePath);
//var newTrie = new Trie();
//for (var i = 0; i < 256; ++i)
//{
//    newTrie.Add(Char.ToString((char)i), i);
//}

//var ewkere = 1;

//var result = new List<byte>();
//var listOfCurrentBits = new List<bool>() {true, true, false, false, true};
//var bitsToAdd = new List<bool>() { true, false, true, false, false, false, false, true};

//var length = listOfCurrentBits.Count();

//for (var i = 0; i + length < 8; ++i)
//{
//    listOfCurrentBits.Add(bitsToAdd[i]);
//}

//result.Add(LZWUtils.ConvertBitsToByte(listOfCurrentBits));
//listOfCurrentBits.Clear();

//listOfCurrentBits = bitsToAdd;

//var ewkere = 1;

//var ewkere = 1;

//var result = LZWZip.Compress(filePath);
//Console.WriteLine(result);

var encoder = new LZWEncode();
encoder.Encode(filePath, newFilePath);


var firstFileSize = (new FileInfo(filePath)).Length;
var secondFileSize = (new FileInfo(newFilePath)).Length;

Console.WriteLine((double)secondFileSize / (double)firstFileSize);

Console.WriteLine(LZWArchiver.Compress(filePath));

LZWArchiver.Decompress(newFilePath);

