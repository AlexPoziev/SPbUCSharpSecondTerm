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

    // Check that array-sequence 0..expectedLength - 1 filled right
    public static bool IsArrayFilledBySequenceRight(int expectedLength, in int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array can't be null");
        }

        if (array.Length != expectedLength)
        {
            return false;
        }

        for (int i = 0; i < expectedLength; ++i)
        {
            if (array[i] != i)
            {
                return false;
            }
        }

        return true;
    }
}

