namespace Sorting;

// class for utils to work with arrays
public static class ArrayUtils
{
    public static void PrintArray(int[] ints)
    {
        if (ints == null)
        {
            throw new ArgumentException("Can't be null", nameof(ints));
        }

        foreach (int item in ints)
        {
            Console.WriteLine($"{item}");
        }
    }
}