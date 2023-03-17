namespace UniqueList;

public class List<T>
{
    private int size;

    public int Size() => size;

    Node? head;

    private Node GetNodeByPosition(int position)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (size == 0)
        {
            throw new InvalidOperationException("Can't to get node from empty list");
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
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (size == 0)
        {
            throw new InvalidOperationException("Can't to get value from empty list");
        }

        return GetNodeByPosition(position).Value;
    }

    public void Add(int position, T value)
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

    public void ChangeValue(int position, T newValue)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (size == 0)
        {
            throw new InvalidOperationException("Can't to change value in the empty list");
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

    private class Node
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

