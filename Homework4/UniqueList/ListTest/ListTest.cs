namespace ListTest;

using Lists;

public class ListTests
{
    private static bool AreValuesArrayAndListSame(List<int> list, int[] array)
    {
        if (list.Size != array.Length)
        {
            return false;
        }

        for (int i = 0; i < list.Size; ++i)
        {
            if (list.GetValue(i) != array[i])
            {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<TestCaseData> Lists
    {
        get
        {
            var lists = new Lists.List<int>[]
            {
                new Lists.List<int>(),
                new Lists.UniqueList<int>()
            };

            var data = new[] { 1, 2, 3, 4, 5 };

            var position = new[] { 0, 1, 2, 1, 0 };

            var result = new System.Collections.Generic.List<TestCaseData>();

            foreach (var list in lists)
            {
                for (var i = 0; i < data.Length; ++i)
                {
                    list.Add(position[i], data[i]);
                }

                result.Add(new TestCaseData(list));
            }

            return result;
        }
    }


    [TestCaseSource(nameof(Lists))]
    public void AddAndGetValueAndSizeShouldPerformExpectedResult(List<int> list)
    {
        const int expectedResultSize = 5;
        var expectedResultArray = new int[expectedResultSize] { 5, 1, 4, 2, 3 };

        Assert.That(AreValuesArrayAndListSame(list, expectedResultArray));
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveShouldDeleteElementFromList(List<int> list)
    {
        var expectedResultArray = new[] { 1, 4, 3 };

        list.Remove(0);
        list.Remove(2);

        Assert.That(AreValuesArrayAndListSame(list, expectedResultArray));
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveOutOfRangePositionShouldThrowArgumentRemoveException(List<int> list)
    {
        var emptyList = new List<int>();

        Assert.Throws<InvalidRemoveOperationException>(() => emptyList.Remove(0));
        Assert.Throws<InvalidRemoveOperationException>(() => list.Remove(-1));
        Assert.Throws<InvalidRemoveOperationException>(() => list.Remove(list.Size));
        Assert.Throws<InvalidRemoveOperationException>(() => list.Remove(list.Size + 1));
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeValueShouldOnlyChangeValueOfOneElement(List<int> list)
    {
        var expectedResultArray = new[] { 0, 1, 4, 2, 3 };

        list.ChangeValue(0, 0);

        Assert.That(AreValuesArrayAndListSame(list, expectedResultArray));
    }

    [TestCaseSource(nameof(Lists))]
    public void IndexerShouldReturnRealContainment(List<int> list)
    {
        const int expectedResultSize = 5;
        var expectedResultArray = new[] { 5, 1, 4, 2, 3 };
        var isPassed = true;

        for (int i = 0; i < expectedResultSize; ++i)
        {
            isPassed = isPassed && list[i] == expectedResultArray[i];
        }

        Assert.That(isPassed);
    }
}
