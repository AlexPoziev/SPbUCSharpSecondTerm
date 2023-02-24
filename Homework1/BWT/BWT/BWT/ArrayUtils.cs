namespace Algorithms;

public class ArrayUtils
{
    // Fill array by range 0..array.Length - 1
    public static void FillArrayBySequence(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array can't be null");
        }

        if (array.Length == 0)
        {
            // i think that if we try to fill Empty array by sequence we make something strange
            throw new ArgumentException("Can't to fill empty array", nameof(array));
        }

        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = i;
        }
    }
}

