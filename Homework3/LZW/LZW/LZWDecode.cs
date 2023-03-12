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
        var dictionary = new Dictionary<int, string>();
        for (var i = 0; i < 256; ++i)
        {
            dictionary.Add(i, ((char)i).ToString());
        }

        List<byte> listOfBytes = File.ReadAllBytes(filePath).ToList<byte>();

        string symbol = ((char)listOfBytes.First()).ToString();
        listOfBytes.RemoveAt(0);
        var result = new StringBuilder(symbol);
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

                string entry = dictionary.ContainsKey(newKey)
                    ? dictionary[newKey]
                    : symbol + symbol[0];

                result.Append(entry);
                dictionary.Add(dictionary.Count, symbol + entry[0]);
                symbol = entry;
            }
        }

        string answer = result.ToString();
        File.WriteAllText(newFilePath, answer);
    }
}

