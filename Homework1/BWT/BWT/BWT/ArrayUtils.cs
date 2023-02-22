namespace Algorithms;

public class ArrayUtils
{
    // Fill array by range 0..array.Length - 1
    public static void FillArrayBySequence(int[] array)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = i;
        }
    }

}

