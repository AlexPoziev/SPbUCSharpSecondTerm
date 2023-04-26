namespace SkipList;

public class SkipList<T> : IList<T> where T : IComparable
{
    private readonly SkipListNode head = new (default, new LinkedList<SkipListNode?>());

    private readonly SkipListNode tail = new (default, new LinkedList<SkipListNode?>());

    private LinkedList<SkipListNode> GetPreviousOfSearchedByValue(T value)
    {
        if (value == null)
        {
            return null;
        }

        var currentNode = head;
        SkipListNode? previousNode = null;
        var lastLevelPreviousNodesList = new LinkedList<SkipListNode>();

        for (var currentLevel = head.Next.Count; currentLevel > 0; --currentLevel)
        {
            var compareResult = currentNode.Next.ElementAt(currentLevel).Value.CompareTo(value);
            while (compareResult == 1 && currentNode.Next.ElementAt(currentLevel) != tail)
            {
                currentNode = currentNode.Next.ElementAt(currentLevel);
            }

            lastLevelPreviousNodesList.AddFirst(currentNode);
        }

        return lastLevelPreviousNodesList;
    }

    public bool Contains(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        return resultOfSearch.ElementAt(0) != tail && resultOfSearch.ElementAt(0).Value.CompareTo(value) == 0;
    }

    bool ICollection<T>.IsReadOnly => false;

    public int Count { get; }

    private record SkipListNode(T? Value, LinkedList<SkipListNode?> Next);

    List

    public SkipList()
    {
        head.Next.AddFirst(tail);
    }

}

