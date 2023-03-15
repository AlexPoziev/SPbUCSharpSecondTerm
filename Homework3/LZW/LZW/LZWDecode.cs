namespace LZW;

/// <summary>
/// Class that perfroms decoding of the file by LZW algorithm.
/// </summary>
public class LZWDecode
{
    private readonly int byteSize = 8;

    private int currentPowerOfTwo = 8;
    private int currentMaxNumberOfElementsInDictionary = 256;

    /// <summary>
    /// Method to decode byte array by LZW algorithm.
    /// </summary>
    /// <param name="arrayOfBytes">array of bytes that need to be decoded.</param>
    /// <returns>decoded array of bytes.</returns>
    /// <exception cref="ArgumentNullException">Byte array must to be not null.</exception>
    /// <exception cref="ArgumentException">Byte array must to be not empty.</exception>
    public byte[] Decode(byte[] arrayOfBytes)
    {
        if (arrayOfBytes == null)
        {
            throw new ArgumentNullException(nameof(arrayOfBytes), "Array of bytes can't be null");
        }

        if (!arrayOfBytes.Any())
        {
            throw new ArgumentException("Trying to decompress empty array", nameof(arrayOfBytes));
        }

        var listOfBytes = arrayOfBytes.ToList();

        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(i, newElement);
        }

        var result = InverseLZW(listOfBytes, dictionary);

        ResetDecoder();

        return result.ToArray();
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

            int newKey = BinaryConverter.ConvertBitsToInt(currentByte);

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
        var newByte = BinaryConverter.ConvertIntToBits(byteSize, element);
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

    private void ResetDecoder()
    {
        currentMaxNumberOfElementsInDictionary = 256;
        currentPowerOfTwo = byteSize;
    }
}