namespace Sorting;

// sort by shellsort
public static class ShellSort
{
    // function to swap values of two varriables
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }

    // ShellSort function with Knuth Sequence
    public static void Sort(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "array can't be null");
        }

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
                for (var j = i; j - gap >= 0 && array[j - gap] > array[j]; j -= gap)
                {
                    Swap(ref array[j], ref array[j - gap]);
                }
            }

            gap /= 3;
        }
    }
}