namespace LZW;

using Trees;

/// <summary>
/// class that perfroms encoding of the file by LZW algorithm.
/// </summary>
public class LZWEncode
{
    private readonly int byteSize = 8;

    /// <summary>
    /// Method to encode byte array by LZW algorithm.
    /// </summary>
    /// <param name="arrayOfBytes">byte array that need to be encoded.</param>
    /// <returns>encoded byte array.</returns>
    /// <exception cref="ArgumentException">array of bytes can't be empty.</exception>
    /// <exception cref="ArgumentNullException">array of bytes can't be null.</exception>
    public byte[] Encode(byte[] arrayOfBytes)
    {
        if (arrayOfBytes == null)
        {
            throw new ArgumentNullException(nameof(arrayOfBytes), "Array of bytes can't be null");
        }

        if (!arrayOfBytes.Any())
        {
            throw new ArgumentException("Trying to compress empty array", nameof(arrayOfBytes));
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

        if (!(listOfCurrentBits.Count == 0 || BinaryConverter.ConvertBitsToInt(listOfCurrentBits) == 0))
        {
            while (listOfCurrentBits.Count < byteSize)
            {
                listOfCurrentBits.Add(false);
            }

            result.Add((byte)BinaryConverter.ConvertBitsToInt(listOfCurrentBits));
        }

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