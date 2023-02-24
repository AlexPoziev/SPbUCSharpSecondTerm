namespace Algorithms;

using System.Text;

// class that contain direct and inverse BWT
public static class BWT
{
    // Direct Burrows–Wheeler transform
    // returns transformed string and index of last element
    // throw exception if word == null
    public static (string, int) DirectBWT(in string word)
    {
        if (word == null)
        {
            throw new ArgumentNullException(word, "null can't be parameter");
        }

        if (word == "")
        {
            throw new ArgumentException("Empty string can't be transformed", word);
        }

        var suffixIndexArray = new int[word.Length];
        ArrayUtils.FillArrayBySequence(suffixIndexArray);

        var lastElement = BWTSort.DirectBWTSort(word, suffixIndexArray);

        var bwtString = new StringBuilder();

        for (int i = 0; i < word.Length; ++i)
        {
            bwtString.Append(word[(suffixIndexArray[i] + word.Length - 1) % word.Length]);
        }

        return (bwtString.ToString(), lastElement);
    }

    // Inverse Burrows–Wheeler transform
    // returns origin string
    // throw exception if transformedString == null
    public static string InverseBWT(in string transformedString, int lastElementIndex)
    {
        if (transformedString == null)
        {
            throw new ArgumentNullException(transformedString, "null can't be parameter");
        }

        if (lastElementIndex < 0 || lastElementIndex > transformedString.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(lastElementIndex), "Last element index can't be less than zero and more than string length - 1");
        }

        if (transformedString == "")
        {
            throw new ArgumentException("Empty string can't be transformed back", transformedString);
        }

        var shiftArray = new int[transformedString.Length];
        ArrayUtils.FillArrayBySequence(shiftArray);
        BWTSort.InverseBWTSort(transformedString, shiftArray);

        var originString = new StringBuilder();

        for (int i = 0; i < transformedString.Length; ++i)
        {
            originString.Append(transformedString[shiftArray[lastElementIndex]]);
            lastElementIndex = shiftArray[lastElementIndex];
        }

        return originString.ToString();
    }
}