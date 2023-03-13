using Trees;
using Algorithms;
using System.Linq;
using LZW;

// BWT FROM FILE 
var filePath = args[0];
var useKey = args[1];

var newFilePath = filePath + ".zipped";

//var encoder = new LZWEncode();
//encoder.Encode(filePath, newFilePath);


//var firstFileSize = (new FileInfo(filePath)).Length;
//var secondFileSize = (new FileInfo(newFilePath)).Length;

//Console.WriteLine((double)secondFileSize / (double)firstFileSize);

Console.WriteLine(LZWArchiver.Compress(filePath));

LZWArchiver.Decompress(newFilePath);

