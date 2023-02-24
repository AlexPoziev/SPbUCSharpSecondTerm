namespace Algorithms;

// class that contains sorts for direct and inverse BWT
public static class BWTSort
{
    // function to swap values of two variables
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }

    // function to compare two suffix of <word>, takes two suffix indexes
    // returns true if the first suffix more than the second
    // throw exception if word == null
    private static bool IsSuffixMore(in string word, int firstSuffixIndex, int secondSuffixIndex)
    {
        if (word == null)
        {
            throw new ArgumentNullException(word, "Can't be null");
        }

        if (word == "")
        {
            throw new ArgumentException("Empty string doesn't have suffixes", word);
        }

        if (firstSuffixIndex < 0 || firstSuffixIndex > word.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(firstSuffixIndex), "Last element index can't be less than zero and more than string length - 1");
        }

        if (secondSuffixIndex < 0 || secondSuffixIndex > word.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(secondSuffixIndex), "Last element index can't be less than zero and more than string length - 1");
        }


        for (int i = 0; i < word.Length; ++i)
        {
            if (word[(firstSuffixIndex + i) % word.Length] != word[(secondSuffixIndex + i) % word.Length])
            {
                return word[(firstSuffixIndex + i) % word.Length] > word[(secondSuffixIndex + i) % word.Length];
            }
        }

        return false;
    }

    // ShellSort function with Knuth Sequence
    // BWT interpretation, return position of the last element
    // word immutable
    // throw exception if wrod == null
    // int array must contains array with numbers in range 0..word.Length - 1. They must not to stay in a row
    public static int DirectBWTSort(in string word, int[] array)
    {
        if (word == null)
        {
            throw new ArgumentNullException(word, "Can't be null");
        }

        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Can't be null");
        }

        if (word == "")
        {
            throw new ArgumentException("Can't to sort empty string", word);
        }

        if (!IsArrayFilledBySequenceRight(word.Length, array))
        {
            throw new ArgumentException("Array filled not right(not range 0..word.Length - 1)", nameof(array));
        }

        var lastElement = 0;
        var gap = 1;

        while (gap < array.Length)
        {
            gap = gap * 3 + 1;
        }

        gap /= 3;

        while (gap > 0)
        {
            for (var i = gap; i < array.Length; ++i)
            {
                for (var j = i; j - gap >= 0 && IsSuffixMore(word, array[j - gap], array[j]); j -= gap)
                {
                    if (j == lastElement || j - gap == lastElement)
                    {
                        lastElement = j == lastElement
                            ? (j - gap)
                            : j;
                    }

                    Swap(ref array[j], ref array[j - gap]);
                }
            }

            gap /= 3;
        }

        return lastElement;
    }

    // sort of ints by word values. Mutate ints. Sorting must be stable
    // throw exception if word == null
    // ints array must contains array with numbers in range 0..word.Length - 1. They must not to stay in a row
    public static void InverseBWTSort(in string word, int[] ints)
    {
        if (word == null)
        {
            throw new ArgumentNullException(word, "Can't be null");
        }

        if (ints == null)
        {
            throw new ArgumentNullException(nameof(ints), "Can't be null");
        }

        if (word == "")
        {
            throw new ArgumentException("Can't sort empty string", word);
        }

        if (!IsArrayFilledBySequenceRight(word.Length, ints))
        {
            throw new ArgumentException("Array filled not right(not range 0..word.Length - 1)", nameof(ints));
        }

        for (int i = 0; i < word.Length - 1; ++i)
        {
            for (int j = 0; j < word.Length - 1 - i; ++j)
            {
                if (word[ints[j]] > word[ints[j + 1]])
                {
                    Swap(ref ints[j], ref ints[j + 1]);
                }
            }
        }
    }

    // Check that array filled by 0..expectedLength - 1 numbers
    private static bool IsArrayFilledBySequenceRight(int expectedLength, in int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array can't be null");
        }

        if (array.Length != expectedLength)
        {
            return false;
        }

        var bitMask = new int[expectedLength];
        var currentBitMaskFilling = 0;

        for (int i = 0; i < expectedLength; ++i)
        {
            if (bitMask[array[i]] == 0)
            {
                ++bitMask[array[i]];
                ++currentBitMaskFilling;
            }
            else
            {
                return false;
            }
        }

        return currentBitMaskFilling == expectedLength;
    }
}