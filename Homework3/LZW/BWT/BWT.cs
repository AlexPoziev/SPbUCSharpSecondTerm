namespace Algorithms;

using System.Text;

// class that contain direct and inverse BWT
public static class BWT
{
    // Direct Burrows–Wheeler transform
    // returns transformed string and index of last element
    // throw exception if word == null
    public static (byte[], int) DirectBWT(in byte[] bytes)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes), "null can't be parameter");
        }

        if (!bytes.Any())
        {
            throw new ArgumentException("Empty string can't be transformed", nameof(bytes));
        }

        var suffixIndexArray = new int[bytes.Length];
        ArrayUtils.FillArrayBySequence(suffixIndexArray);

        var lastElement = BWTSort.DirectBWTSort(bytes, suffixIndexArray);

        var bwtString = new List<byte>();

        for (int i = 0; i < bytes.Length; ++i)
        {
            bwtString.Add(bytes[(suffixIndexArray[i] + bytes.Length - 1) % bytes.Length]);
        }

        return (bwtString.ToArray(), lastElement);
    }

    // Inverse Burrows–Wheeler transform
    // returns origin string
    // throw exception if transformedString == null
    public static byte[] InverseBWT(in byte[] tranformedByteArray, int lastElementIndex)
    {
        if (tranformedByteArray == null)
        {
            throw new ArgumentNullException(nameof(tranformedByteArray), "null can't be parameter");
        }

        if (lastElementIndex < 0 || lastElementIndex > tranformedByteArray.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(lastElementIndex), "Last element index can't be less than zero and more than string length - 1");
        }

        if (!tranformedByteArray.Any())
        {
            throw new ArgumentException("Empty string can't be transformed back", nameof(tranformedByteArray));
        }

        var shiftArray = new int[tranformedByteArray.Length];
        ArrayUtils.FillArrayBySequence(shiftArray);
        BWTSort.InverseBWTSort(tranformedByteArray, shiftArray);

        var originByteArray = new List<byte>();

        for (int i = 0; i < tranformedByteArray.Length; ++i)
        {
            originByteArray.Add(tranformedByteArray[shiftArray[lastElementIndex]]);
            lastElementIndex = shiftArray[lastElementIndex];
        }

        return originByteArray.ToArray();
    }
}