namespace ListTest;

using Lists;

public class ListTests
{
    private static IEnumerable<TestCaseData> Lists
    {
        get
        {
            var lists = new Lists.List<int>[]
            {
                new Lists.List<int>(),
                new Lists.UniqueList<int>()
            };

            var data = new int[] { 1, 2, 3, 4, 5 };

            var position = new int[] { 0, 1, 2, 1, 0 };

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
    public void AddAndGetValueShouldPerformExpectedResult(List<int> list)
    {
        const int resultSize = 5;
        var expectedResultArray = new int[resultSize] { 5, 1, 4, 2, 3 };
        bool IsExpectedResult = true;

        for (int i = 0; i < resultSize; ++i)
        {
            IsExpectedResult = IsExpectedResult && list.GetValue(i) == expectedResultArray[i];
        }

        Assert.That(IsExpectedResult);
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveShouldDeleteCommonElementFromList(List<int> list)
    {

    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveOutOfRangePositionShouldThrowArgumentRemoveException()
    {

    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeValueShouldOnlyChangeValueOfOneElement()
    {

    }

    [TestCaseSource(nameof(Lists))]
    public void IndexerShouldReturnRealContainment()
    {

    }
}
