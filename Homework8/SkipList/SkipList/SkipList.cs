using System.Collections;

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

        for (var currentLevel = head.Next.Length - 1; currentLevel >= 0; --currentLevel)
        {
            var compareResult = currentNode.Next[currentLevel].Value.CompareTo(value);
            while (compareResult == -1 && currentNode.Next[currentLevel] != tail)
            {
                currentNode = currentNode.Next[currentLevel];
                compareResult = currentNode.Next[currentLevel].Value.CompareTo(value);
            }

            lastLevelPreviousNodesList[currentLevel] = currentNode;
        }

        return lastLevelPreviousNodesList;
    }

    public bool Contains(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        return resultOfSearch[0].Next[0] != tail && resultOfSearch[0].Next[0].Value.CompareTo(value) == 0;
    }

    public void Insert(int index, T value)
            => throw new NotSupportedException("Insert by a specific index not supported in Skip List data struct");

    public void Add(T value)
    {
        var previousNodes = GetPreviousOfSearchedByValue(value);

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

            newSkipListNode.Next[newNodeSize - 1] = tail;
        }

        ++Count;
    }

    public bool Remove(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        var nextNode = resultOfSearch[0].Next[0];

        if (nextNode != tail && nextNode.Value.CompareTo(value) == 0)
        {
            for (int i = 0; i < resultOfSearch.Length; ++i)
            {
                resultOfSearch[i].Next[i] = nextNode.Next[i];
            }

            --Count;
            
            return true;
        }

        return false;
    }

    public void Clear()
    {
        head = new(default, new SkipListNode[1]);
        head.Next[0] = tail;

        Count = 0;
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

    public int IndexOf(T value)
    {
        var currentNode = head.Next[0];

        var currentIndex = 0;

        while (currentNode != tail)
        {
            if (currentNode.Value.CompareTo(value) == 0)
            {
                return currentIndex;
            }

            currentNode = currentNode.Next[0];

            ++currentIndex;
        }

        return -1;
    }

    public void RemoveAt(int index)
    { }

    public void CopyTo(T[] array, int arrayIndex)
    {
        

        var currentNode = head.Next[0];

        var currentIndex = 0;

        while (currentNode != tail)
        {
            currentNode = currentNode.Next[0];

            ++currentIndex;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    bool ICollection<T>.IsReadOnly => false;

    public int Count { get; private set; } = 0;

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private record SkipListNode(T? Value, SkipListNode[] Next);

    public SkipList()
    {
        head.Next[0] = tail;
    }
}

