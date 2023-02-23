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

    // Check that array filled by 0..expectedLength - 1 numbers
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

