namespace SkipListTest;

using Lists;

public class Tests
{
    SkipList<int> skipList;

    [SetUp]
    public void SetUp()
            => skipList = new SkipList<int>();

    [Test]
    public void RemoveAtNotExistingIndexShouldReturnFalse()
            => Assert.That(skipList.Remove(default), Is.False);

    [TestCase(1, 0)]
    [TestCase(4, 1, 1, 1, 2)]
    [TestCase(0)]
    public void CountShouldPerformExpectedResult(int expectedResult, params int[] elementsToAdd)
    {
        Array.ForEach(elementsToAdd, skipList.Add);

        Assert.That(skipList, Has.Count.EqualTo(expectedResult));
    }

    [Test]
    public void CountAfterCleanShouldReturnZero()
    {
        var primaryData = new[] { 5, 6, 11, 10, 13 };

        Array.ForEach(primaryData, skipList.Add);

        skipList.Clear();

        Assert.That(skipList, Has.Count.EqualTo(default(int)));
    }

    [Test]
    public void RemoveOfNotExistingValueShouldReturnFalse()
            => Assert.That(skipList.Remove(default), Is.False);

    [TestCase(-1, 5)]
    [TestCase(0, 5, 5, 6, 11, 10, 13)]
    public void IndexOfShouldPerformExpectedResult(int expectedResult, int elementToSearchFor, params int[] elementsToAdd)
    {
        Array.ForEach(elementsToAdd, skipList.Add);

        Assert.That(skipList.IndexOf(elementToSearchFor), Is.EqualTo(expectedResult));
    }

    [Test]
    public void InsertShouldThrowsNotSupportedException()
            => Assert.Throws<NotSupportedException>(() => skipList.Insert(default, default));

    [Test]
    public void RemoveAtShouldPerformExpectedResult()
    {
        var primaryData = new int[] { 5, 6, 11, 10, 13 };

        var indexToRemove = 3;
        var valueThatShouldToBeRemoved = 11;

        Array.ForEach(primaryData, skipList.Add);

        skipList.RemoveAt(indexToRemove);

        Assert.That(skipList, Does.Not.Contain(valueThatShouldToBeRemoved));
    }

    [TestCase(false, 0)]
    [TestCase(true, 1, 1)]
    [TestCase(true, 0, 1, 5, 0, -10)]
    [TestCase(false, 0, 1, 2, 3, 4, 5)]
    public void ContainsShouldPerformExpectedResult(bool expectedResult, int elementToSearchFor, params int[] elementsToAdd)
    {
        Array.ForEach(elementsToAdd, skipList.Add);

        Assert.That(skipList.Contains(elementToSearchFor), Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddRemoveBeforeContainsShouldPerformExpectedResult()
    {
        var valueToCheckContainment = 1;

        skipList.Add(valueToCheckContainment);
        skipList.Remove(valueToCheckContainment);

        Assert.That(skipList, Does.Not.Contain(valueToCheckContainment));
    }

    [Test]
    public void CorrectCopyToShouldPerformExpectedResult()
    {
        var expectedArray = new[] { 1, 2, 10, 15 };

        var actualArray = new[] { 1, 2, 100, 150 };

        var indexToCopyTo = 2;

        skipList.Add(10);
        skipList.Add(15);

        skipList.CopyTo(actualArray, indexToCopyTo);

        Assert.That(actualArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void IndexerShouldReturnExpectedResult()
    {
        var expectedResult = 11;

        Array.ForEach(new[] { 6, 5, 10, 13, 11 }, skipList.Add);

        Assert.That(skipList[3], Is.EqualTo(expectedResult));
    }

    [Test]
    public void IndexerWithIndexLargerThanListSizeShouldThrowsIndexOutOfRangeException()
    {
        int index = 10;

        Assert.Throws<IndexOutOfRangeException>(() => index = skipList[0]);
    }

    [Test]
    public void SetByIndexerShouldThrowsNotSupportedException()
            => Assert.Throws<NotSupportedException>(() => skipList[0] = 1);

    [Test]
    public void CopyToOutOfRangeShouldThrowsArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => skipList.CopyTo(Array.Empty<int>(), 1));

    [Test]
    public void CopyToWithNotEnoughSpaceForListShouldThrowsArgumentException()
    {
        var arrayToAddToList = new[] { 1, 2, 100, 150 };

        var arrayToCopyTo = new[] { 3, 5, 6 };

        Array.ForEach(arrayToAddToList, skipList.Add);

        Assert.Throws<ArgumentException>(() => skipList.CopyTo(arrayToCopyTo, 0));
    }

    [Test]
    public void IteratorShouldPerformExpectedRe()
    {
        Array.ForEach(new[] { 5, 6, 11, 10, 13 }, skipList.Add);

        var expected = new[] { 5, 6, 10, 11, 13 };

        var actual = new List<int>();
        foreach (var value in skipList)
        {
            actual.Add(value);
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ModifingOfSkipListInIteratorShouldThrowInvalidOperationException()
    {
        Array.ForEach(new[] { 5, 6, 10, 11, 13 }, skipList.Add);

        var iterator = skipList.GetEnumerator();

        skipList.Remove(13);

        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }
}