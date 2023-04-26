namespace SkipList;

public class SkipList<T> : IList<T> where T : IComparable
{
    private SkipListNode head = new (default, new SkipListNode[1]);

    private readonly SkipListNode tail = new (default, Array.Empty<SkipListNode>());

    private SkipListNode[] GetPreviousOfSearchedByValue(T value)
    {
        if (value == null)
        {
            return null;
        }

        var currentNode = head;

        var lastLevelPreviousNodesList = new SkipListNode[head.Next.Length];

        for (var currentLevel = head.Next.Length; currentLevel > 0; --currentLevel)
        {
            var compareResult = currentNode.Next[currentLevel].Value.CompareTo(value);
            while (compareResult == 1 && currentNode.Next[currentLevel] != tail)
            {
                currentNode = currentNode.Next[currentLevel];
            }

            lastLevelPreviousNodesList[currentLevel] = currentNode;
        }

        return lastLevelPreviousNodesList;
    }

    public bool Contains(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        return resultOfSearch[0] != tail && resultOfSearch[0].Value.CompareTo(value) == 0;
    }

    public void Insert(int index, T value)
    {

    }

    public void Add(T value)
    {
        var previousNodes = GetPreviousOfSearchedByValue(value);

        CreateAndPutRandomHeightSkipListNode(value, previousNodes);
    }

    public void Clear()
    {
        head = new(default, new SkipListNode[1]);
        head.Next[0] = tail;
    }

    private SkipListNode CreateAndPutRandomHeightSkipListNode(T value, SkipListNode[] previousNodes)
    {
        var newNodeSize = GetRandomSkipListNodeHeight();

        var newSkipListNode = new SkipListNode(value, new SkipListNode[newNodeSize]);

        for (int i = 0; i < newNodeSize && i < head.Next.Length; ++i)
        {
            newSkipListNode.Next[i] = previousNodes[i].Next[i];
            previousNodes[i].Next[i] = newSkipListNode;
        }

        if (newNodeSize > head.Next.Length)
        {
            var newHeadNext = new SkipListNode(default, new SkipListNode[newNodeSize]);
            head.Next.CopyTo(newHeadNext.Next, 0);
            newHeadNext.Next[newNodeSize - 1] = newSkipListNode;
            head = newHeadNext;
        }

        return newSkipListNode;
    }

    private int GetRandomSkipListNodeHeight()
    {
        const int increaseNumber = 1;

        var random = new Random();

        var currentSize = 1;

        while (currentSize <= head.Next.Length)
        {
            if (random.Next(0, 2) != increaseNumber)
            {
                break;
            }

            ++currentSize;
        }

        return currentSize;
    }

    bool ICollection<T>.IsReadOnly => false;

    public int Count { get; }

    private record SkipListNode(T? Value, SkipListNode[] Next);
}

