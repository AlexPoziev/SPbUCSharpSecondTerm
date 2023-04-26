using System.Collections;

namespace Lists;

public class SkipList<T> : IList<T> where T : IComparable
{
    private int currentListVersion;

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

        ++currentListVersion;
            
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

            ++currentListVersion;


            return true;
        }

        return false;
    }

    public void Clear()
    {
        head = new(default, new SkipListNode[1]);
        head.Next[0] = tail;

        ++currentListVersion;

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
            => Remove(this[index]);

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(array), "Array index less than zero");
        }

        if (array.Length - arrayIndex < Count || arrayIndex >= array.Length)
        {
            throw new ArgumentException("Skip List larger than gap to copy in.", nameof(arrayIndex));
        }

        var currentNode = head.Next[0];

        var currentIndex = arrayIndex;

        while (currentNode != tail)
        {
            array[currentIndex] = currentNode.Value;

            currentNode = currentNode.Next[0];
            ++currentIndex;
        }
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public class Enumerator : IEnumerator<T>
    {
        private readonly int enumeratorListVersion;

        SkipListNode currentNode;

        private readonly SkipList<T> skipList;

        public Enumerator(SkipList<T> skipList)
        {
            if (skipList == null)
            {
                throw new ArgumentNullException(nameof(skipList));
            }

            this.skipList = skipList;

            enumeratorListVersion = skipList.currentListVersion;

            currentNode = skipList.head;
        }

        public T Current
        {
            get
            {
                if (currentNode == skipList.head)
                {
                    throw new InvalidOperationException("Can't to get current before the first MoveNext");
                }

                return currentNode.Value!;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (enumeratorListVersion != skipList.currentListVersion)
            {
                throw new InvalidOperationException("After the enumerator was created, the data struct was changed.");
            }

            if (currentNode == skipList.tail || currentNode.Next[0] == skipList.tail)
            {
                return false;
            }

            currentNode = currentNode.Next[0];

            return true;
        }

        public void Reset()
        {
            if (enumeratorListVersion != skipList.currentListVersion)
            {
                throw new InvalidOperationException("After the enumerator was created, the data struct was changed.");
            }

            currentNode = skipList.head;
        }
    }

    bool ICollection<T>.IsReadOnly => false;

    public int Count { get; private set; } = 0;

    public T this[int index] {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head.Next[0];

            for (int i = 0; i < index; ++i)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value;
        }
        set => throw new NotSupportedException("Can't change value by indexer.");
    }
    
    private record SkipListNode(T? Value, SkipListNode[] Next);

    public SkipList()
    {
        head.Next[0] = tail;
    }
}

