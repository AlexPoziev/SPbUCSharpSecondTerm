namespace SortingTest;

public class ShellSortTest
{
    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 4, 2, 3, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 5, 4, 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1 }, new int[] { 1 })]
    [TestCase(new int[] { int.MaxValue, 1, int.MinValue }, new int[] { int.MinValue, 1, int.MaxValue })]
    [TestCase(new int[] { 1, 2, 1, 3, 4, 3}, new int[] { 1, 1, 2, 3, 3, 4 })]
    [TestCase(new int[] {  }, new int[] {  })]
    public void SimpleSortTest(int[] array, int[] expected)
    {
        Sorting.ShellSort.Sort(array);

        Assert.That(expected, Is.EqualTo(array));
    }

    [Test]
    public void RandomNumberTest()
    {
        const int testArraySize = 100;
        Random randomNums = new Random();
        int[] array = new int[testArraySize];
        int[] nativeArray = new int[testArraySize];

        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = randomNums.Next();
            nativeArray[i] = array[i];
        }

        Sorting.ShellSort.Sort(array);
        Array.Sort(nativeArray);

        // at the same time check that no values lost and that array is sorted
        Assert.That(Enumerable.SequenceEqual(nativeArray, array), Is.True);
    }
}