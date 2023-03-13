using Trees;
using System.Text;
using System.Diagnostics.Metrics;

namespace LZW;

public class LZWDecode
{
    readonly private int byteSize = 8;

    private int currentPowerOfTwo = 8;
    private int currentMaxNumberOfElementsInDictionary = 256;

    public void Decode(string filePath, string newFilePath)
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(i, newElement);
        }

        var listOfBytes = File.ReadAllBytes(filePath).ToList<byte>();

        var firstByte = new List<byte>();
        firstByte.Add(listOfBytes.First());
        listOfBytes.RemoveAt(0);

        var result = new List<byte>();
        result.Add(firstByte[0]);
        var currentByte = new List<bool>();
        var remainingBits = new List<bool>();

        foreach (var element in listOfBytes)
        {
            if (dictionary.Count  == currentMaxNumberOfElementsInDictionary)
            {
                ++currentPowerOfTwo;
                currentMaxNumberOfElementsInDictionary *= 2;
            }

            var newByte = LZWUtils.ConvertIntToBits(byteSize, element);
            while (newByte.Count > 0)
            {
                remainingBits.Add(newByte.ElementAt(0));
                newByte.RemoveAt(0);
            }

            if (remainingBits.Count < currentPowerOfTwo)
            {
                continue;
            }

            while (remainingBits.Count >= currentPowerOfTwo)
            {
                while (currentByte.Count < currentPowerOfTwo)
                {
                    currentByte.Add(remainingBits.ElementAt(0));
                    remainingBits.RemoveAt(0);
                }

                int newKey = LZWUtils.ConvertBitsToInt(currentByte);

                currentByte.Clear();

                List<byte> entry;
                if (dictionary.ContainsKey(newKey))
                {
                    entry = dictionary[newKey];
                }
                else
                {
                    firstByte.Add(firstByte[0]);
                    entry = firstByte;
                }

                result.AddRange(entry);

                var newElement = new List<byte>();
                newElement.AddRange(firstByte);
                newElement.Add(entry[0]);
                dictionary.Add(dictionary.Count, newElement);

                firstByte = entry;
            }
        }

        File.WriteAllBytes(newFilePath, result.ToArray());
    }
}

