using System;

namespace Algorithms
{
    public static class BWTSort
    {
        // function to swap values of two variables
        private static void Swap(ref int First, ref int Second)
        {
            (First, Second) = (Second, First);
        }

        // Fill array by range 0..array.Length - 1
        public static void FillArrayBySequence(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = i;
            }
        }

        // function to compare two suffix of <word>, takes two suffix indexes
        // returns true if the first suffix more than the second
        public static bool IsSuffixMore(in string word, int firstSuffixIndex, int secondSuffixIndex)
        {
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
        public static int DirectBWTSort(in string word, int[] array)
        {
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
        public static void InverseBWTSort(in string word, int[] ints)
        {
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
    }
}