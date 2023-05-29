namespace ListTest;

using Lists;

public class UniqueListExceptionsTest
{
    UniqueList<int> list;

    [SetUp]
    public void Setup()
    {
        list = new UniqueList<int>();

        list.Add(0, 1);
        list.Add(1, 2);
        list.Add(2, 3);
    }

    [Test]
    public void AddExistsElementShouldThrowException()
    {
        Assert.Throws<InvalidOperationValueAlreadyExistsException>(() => list.Add(3, 1));
    }

    [Test]
    public void ChangeToNewElementShouldThrowException()
    {
        Assert.Throws<InvalidOperationValueAlreadyExistsException>(() => list.ChangeValue(2, 1));
    }

    [Test]
    public void ChangeToOldElementShouldThrowException()
    {
        Assert.DoesNotThrow(() => list.ChangeValue(0, 1));
    }
}

