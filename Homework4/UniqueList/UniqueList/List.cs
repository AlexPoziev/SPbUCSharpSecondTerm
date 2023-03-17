namespace Lists;

public class List<T>
{
    private protected int size;

    public int Size() => size;

    private protected Node? head;

    public T this[int i]
    {
        get { return GetValue(i); }
        set { ChangeValue(i, value); }
    }

    private Node GetNodeByPosition(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        var currentNode = this.head;

        for (int i = 0; i < position; ++i)
        {
            currentNode = currentNode!.Next;
        }

        return currentNode!;
    }

    public T GetValue(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        return GetNodeByPosition(position).Value;
    }

    public virtual void Add(int position, T value)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (position == 0)
        {
            head = new Node(value, head?.Next);
        }
        else
        {
            var previousNode = GetNodeByPosition(position - 1);
            var newNode = new Node(value, previousNode.Next);
            previousNode.Next = newNode;
        }

        ++size;
    }

    public virtual void ChangeValue(int position, T newValue)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        GetNodeByPosition(position).Value = newValue;
    }

    public void Remove(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentRemoveOutOfRangeException();
        }

        if (position == 0)
        {
            head = head?.Next;
        }
        else
        {
            var previousNode = GetNodeByPosition(position - 1);
            previousNode.Next = previousNode.Next!.Next;
        }

        --size;
    }

    private protected class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }

        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }
}

