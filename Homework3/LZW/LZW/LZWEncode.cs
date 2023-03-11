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
            trie.Add(Char.ToString((char)i), i);
        }

        byte[] arrayOfBytes = File.ReadAllBytes(filePath);

        string newChars = "";
        List<byte> result = new();
        var listOfCurrentBits = new List<bool>();

        for (int i = 0; i < arrayOfBytes.Length; ++i)
        {
            string elementToAdd = newChars + (char)arrayOfBytes[i];
            if (trie.Contains(elementToAdd))
            {
                newChars = elementToAdd;
            }
            else
            {
                var stringKey = trie.GetValueOfElement(newChars);
                var bitsToAdd = LZWUtils.ConvertIntToBits(currentPowerOfTwo, stringKey);

                AddNewByte(bitsToAdd, ref listOfCurrentBits, result);

                if (trie.Size == currentMaxNumberOfElementsInTrie)
                {
                    ++currentPowerOfTwo;
                    currentMaxNumberOfElementsInTrie *= 2 + 2;
                }

                trie.Add(elementToAdd, trie.Size + 1);
                newChars = ((char)arrayOfBytes[i]).ToString();
            }
        }

        File.WriteAllBytes(newFilePath, result.ToArray());
    }

    private void AddNewByte(List<bool> bitsToAdd , ref List<bool> listOfCurrentBits, List<byte> result)
    {
        while (bitsToAdd.Count + listOfCurrentBits.Count >= byteSize)
        {
            for (var i = 0; i + listOfCurrentBits.Count < byteSize; ++i)
            {
                listOfCurrentBits.Add(bitsToAdd[i]);
            }

            result.Add(LZWUtils.ConvertBitsToByte(listOfCurrentBits));
            listOfCurrentBits.Clear();
        }

        listOfCurrentBits = bitsToAdd;
    }
}

