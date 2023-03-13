using Trees;
using System.Text;
using System.Diagnostics.Metrics;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;

namespace LZW;

/// <summary>
/// Class that perfroms decoding of the file by LZW algorithm
/// </summary>
public class LZWDecode
{
    readonly private int byteSize = 8;

    private int currentPowerOfTwo = 8;
    private int currentMaxNumberOfElementsInDictionary = 256;

    /// <summary>
    /// Method to decode file by LZW algorithm
    /// </summary>
    /// <param name="filePath">The path of the file that need to be decompressed</param>
    /// <param name="newFilePath">The path of the file to write decompressed result</param>
    /// <exception cref="ArgumentException">Files must to exist. filePath must to not be empty </exception>
    public void Decode(string filePath, string newFilePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("No file with this path exists", nameof(filePath));
        }

        if (!File.Exists(newFilePath))
        {
            throw new ArgumentException("No file with this path exists", nameof(newFilePath));
        }

        var listOfBytes = File.ReadAllBytes(filePath).ToList<byte>();
        if (listOfBytes == null || !listOfBytes.Any())
        {
            throw new ArgumentException("Trying to compress empty file", nameof(filePath));
        }

        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(i, newElement);
        }

        var result = InverseLZW(listOfBytes, dictionary);

        File.WriteAllBytes(newFilePath, result.ToArray());
    }

    private List<byte> InverseLZW(List<byte> listOfBytes, Dictionary<int, List<byte>> dictionary)
    {
        var firstByte = new List<byte>();
        firstByte.Add(listOfBytes.First());
        listOfBytes.RemoveAt(0);

        var result = new List<byte>();
        result.Add(firstByte[0]);

        var currentByte = new List<bool>();
        var remainingBits = new List<bool>();

        foreach (var element in listOfBytes)
        {
            if (dictionary.Count == currentMaxNumberOfElementsInDictionary)
            {
                ++currentPowerOfTwo;
                currentMaxNumberOfElementsInDictionary *= 2;
            }

            if (!PrepareNewByte(element, remainingBits, currentByte))
            {
                continue;
            }

            int newKey = LZWUtils.ConvertBitsToInt(currentByte);

            currentByte.Clear();

            List<byte> entry = new List<byte>();
            if (dictionary.ContainsKey(newKey))
            {
                entry.AddRange(dictionary[newKey]);
            }
            else
            {
                // 9 hours of debug broke here
                entry.AddRange(firstByte);
                entry.Add(firstByte[0]);
            }

            result.AddRange(entry);

            var newElement = new List<byte>();

            newElement.AddRange(firstByte);
            newElement.Add(entry[0]);
            dictionary.Add(dictionary.Count, newElement);

            firstByte = entry;
        }

        return result;
    }

    private bool PrepareNewByte(byte element, List<bool> remainingBits, List<bool> currentByte)
    {
        var newByte = LZWUtils.ConvertIntToBits(byteSize, element);
        while (newByte.Count > 0)
        {
            remainingBits.Add(newByte.ElementAt(0));
            newByte.RemoveAt(0);
        }

        if (remainingBits.Count < currentPowerOfTwo)
        {
            return false;
        }

        while (currentByte.Count < currentPowerOfTwo)
        {
            currentByte.Add(remainingBits.ElementAt(0));
            remainingBits.RemoveAt(0);
        }

        return true;
    }

    private void resetDecoder()
    {
        currentMaxNumberOfElementsInDictionary = 256;
        currentPowerOfTwo = byteSize;
    }
}