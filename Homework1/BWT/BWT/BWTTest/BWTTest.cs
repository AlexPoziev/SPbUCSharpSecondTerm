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

        Algorithms.ArrayUtils.FillArrayBySequence(actual);

        Assert.That(Enumerable.SequenceEqual(actual, expected));
    }

    [TestCase(true, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 7)]
    [TestCase(false, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 5)]
    [TestCase(false, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 8)]
    [TestCase(false, new int[] { 0, 1, 2, 3, 2, 5, 6 }, 7)]
    [TestCase(true, new int[] { 0, 2, 1, 3, 4, 6, 5 }, 7)]
    public void IsArrayFilledBySequenceRight(bool expected, int[] array, int expectedLength)
    {
        bool actual;

        actual = Algorithms.ArrayUtils.IsArrayFilledBySequenceRight(expectedLength, array);

        Assert.That(actual, Is.EqualTo(expected: expected));
    }

    [TestCase("banana", new int[] { 1, 3, 5, 0, 2, 4 })]
    [TestCase("mississippi", new int[] { 1, 4, 7, 10, 0, 8, 9, 2, 3, 5, 6 })]
    public void InverseBWTSortTest(string word, int[] expected)
    {
        var actual = new int[word.Length];

        Algorithms.ArrayUtils.FillArrayBySequence(actual);
        Algorithms.BWTSort.InverseBWTSort(word, actual);

        Assert.That(Enumerable.SequenceEqual(expected, actual));
    }

    [TestCase("banana", "nnbaaa", 3)]
    [TestCase("mississippi", "pssmipissii", 4)]
    [TestCase("a", "a", 0)]
    public void DirectBWTTest(string word, string expectedWord, int expectedIndex)
    {
        int actualIndex;

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
