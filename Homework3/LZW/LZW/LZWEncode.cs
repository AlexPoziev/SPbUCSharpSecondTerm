namespace LZW;

using Trees;

/// <summary>
/// class that perfroms encoding of the file by LZW algorithm
/// </summary>
public class LZWEncode
{
    private readonly int byteSize = 8;

    /// <summary>
    /// Method to encode file by LZW algorithm.
    /// </summary>
    /// <param name="filePath">The path of the file that need to be compressed.</param>
    /// <param name="newFilePath">The path of the file to write compressed result.</param>
    /// <exception cref="ArgumentException">Files must to exist. filePath must to not be empty.</exception>
    public byte[] Encode(byte[] arrayOfBytes)
    {
        if (arrayOfBytes == null || !arrayOfBytes.Any())
        {
            throw new ArgumentException("Trying to compress empty data", nameof(arrayOfBytes));
        }

        int currentPowerOfTwo = byteSize;
        int currentMaxNumberOfElementsInTrie = 256;

        var trie = new Trie();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            trie.Add(newElement, i);
        }

        var newBytes = new List<byte>();
        List<byte> result = new ();
        var listOfCurrentBits = new List<bool>();

        for (int i = 0; i < arrayOfBytes.Length; ++i)
        {
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(newBytes);
            elementToAdd.Add(arrayOfBytes[i]);

            if (trie.Contains(elementToAdd))
            {
                newBytes = elementToAdd;
            }
            else
            {
                var key = trie.GetValueOfElement(newBytes);
                var bitsToAdd = BinaryConverter.ConvertIntToBits(currentPowerOfTwo, key);

                AddNewByte(bitsToAdd, ref listOfCurrentBits, result);

                if (trie.Size == currentMaxNumberOfElementsInTrie)
                {
                    ++currentPowerOfTwo;
                    currentMaxNumberOfElementsInTrie *= 2;
                }

                trie.Add(elementToAdd, trie.Size);

                newBytes.Clear();
                newBytes.Add(arrayOfBytes[i]);
            }
        }

        var lastKey = trie.GetValueOfElement(newBytes);
        var bitToAdd = BinaryConverter.ConvertIntToBits(currentPowerOfTwo, lastKey);

        AddNewByte(bitToAdd, ref listOfCurrentBits, result);

        while (listOfCurrentBits.Count < byteSize)
        {
            listOfCurrentBits.Add(false);
        }

        result.Add((byte)BinaryConverter.ConvertBitsToInt(listOfCurrentBits));

        return result.ToArray();
    }

    private void AddNewByte(List<bool> bitsToAdd, ref List<bool> listOfCurrentBits, List<byte> result)
    {
        while (bitsToAdd.Count + listOfCurrentBits.Count >= byteSize)
        {
            for (var i = 0; listOfCurrentBits.Count < byteSize; ++i)
            {
                var firstElement = bitsToAdd.First();
                bitsToAdd.RemoveAt(0);
                listOfCurrentBits.Add(firstElement);
            }

            result.Add((byte)BinaryConverter.ConvertBitsToInt(listOfCurrentBits));
            listOfCurrentBits.Clear();
        }

        listOfCurrentBits = bitsToAdd;
    }
}