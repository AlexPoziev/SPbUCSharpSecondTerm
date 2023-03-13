using Trees;

namespace LZW;

public class LZWEncode
{
    readonly private int byteSize = 8;

    private int currentPowerOfTwo = 8;
    private int currentMaxNumberOfElementsInTrie = 256;

    public void Encode(string filePath, string newFilePath)
    {
        var trie = new Trie();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte) i);
            trie.Add(newElement, i);
        }

        byte[] arrayOfBytes = File.ReadAllBytes(filePath);

        var newBytes = new List<byte>();
        List<byte> result = new();
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
                var bitsToAdd = LZWUtils.ConvertIntToBits(currentPowerOfTwo, key);

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
        var bitToAdd = LZWUtils.ConvertIntToBits(currentPowerOfTwo, lastKey);

        AddNewByte(bitToAdd, ref listOfCurrentBits, result);

        while (listOfCurrentBits.Count < byteSize)
        {
            listOfCurrentBits.Add(false);
        }

        result.Add((byte)LZWUtils.ConvertBitsToInt(listOfCurrentBits));

        File.WriteAllBytes(newFilePath, result.ToArray());
    }

    private void AddNewByte(List<bool> bitsToAdd , ref List<bool> listOfCurrentBits, List<byte> result)
    {
        while (bitsToAdd.Count + listOfCurrentBits.Count >= byteSize)
        {
            for (var i = 0; listOfCurrentBits.Count < byteSize; ++i)
            {
                var firstElement = bitsToAdd.First();
                bitsToAdd.RemoveAt(0);
                listOfCurrentBits.Add(firstElement);
            }

            result.Add((byte)LZWUtils.ConvertBitsToInt(listOfCurrentBits));
            listOfCurrentBits.Clear();
        }

        listOfCurrentBits = bitsToAdd;
    }
}

