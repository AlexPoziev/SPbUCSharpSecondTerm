namespace BWTTest;

public class Tests
{
    [TestCase("banana", new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 3, 1, 0, 4, 2 }, 3)]
    [TestCase("dcba", new int[] { 0, 1, 2, 3 }, new int[] { 3, 2, 1, 0 }, 3)]
    public void DirectBWTSortTest(string word, int[] actualArray, int[] expectedArray, int expectedLastIndex)
    {
        var actualLastIndex = Algorithms.BWTSort.DirectBWTSort(word, actualArray);

        Assert.That(Enumerable.SequenceEqual(actualArray, expectedArray) && actualLastIndex == expectedLastIndex);
    }

    [Test]
    public void FillArrayTest()
    {
        var actual = new int[7];
        var expected = new int[] { 0, 1, 2, 3, 4, 5, 6 };

        Algorithms.BWTSort.FillArrayBySequence(actual);

        Assert.That(Enumerable.SequenceEqual(actual, expected));
    }

    [TestCase("banana", 0, 1, true)]
    [TestCase("banana", 0, 0, false)]
    [TestCase("banana", 0, 2, false)]
    [TestCase("banana", 3, 5, true)]
    public void IsSuffixMoreTest(string word, int first, int second, bool expected)
    {
        Assert.That(Algorithms.BWTSort.IsSuffixMore(word, first, second), Is.EqualTo(expected));
    }

    [TestCase("banana", new int[] { 1, 3, 5, 0, 2, 4 })]
    [TestCase("mississippi", new int[] { 1, 4, 7, 10, 0, 8, 9, 2, 3, 5, 6 })]
    public void InverseBWTSortTest(string word, int[] expected)
    {
        var actual = new int[word.Length];

        Algorithms.BWTSort.FillArrayBySequence(actual);
        Algorithms.BWTSort.InverseBWTSort(word, actual);

        Assert.That(Enumerable.SequenceEqual(expected, actual));
    }

    [TestCase("banana", "nnbaaa", 3)]
    [TestCase("mississippi", "pssmipissii", 4)]
    [TestCase("a", "a", 0)]
    public void DirectBWTTest(string word, string expectedWord, int expectedIndex)
    {
        var actualIndex = 0;

        (word, actualIndex) = Algorithms.BWT.DirectBWT(word);

        Assert.That(actualIndex == expectedIndex && expectedWord == word);
    }

    [TestCase("nnbaaa", 3, "banana")]
    [TestCase("pssmipissii", 4, "mississippi")]
    [TestCase("a", 0, "a")]
    [TestCase("nuuffye", 5, "ufufney")]
    public void InverseBWTTest(string word, int lastIndex, string expecterWord)
    {
        word = Algorithms.BWT.InverseBWT(word, lastIndex);

        Assert.That(Enumerable.SequenceEqual(word, expecterWord));
    }
}
