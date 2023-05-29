namespace Lists;

/// <summary>
/// Class of collection List, that can to add element withoud rebuilding whole collection.
/// </summary>
/// <typeparam name="T">Type of list values.</typeparam>
public class List<T>
{
    /// <summary>
    /// field to control size of List.
    /// </summary>
    private protected int size;

    /// <summary>
    /// The first element of the List.
    /// </summary>
    private protected Node? head;

    /// <summary>
    /// Property to check size of List.
    /// </summary>
    /// <returns>List size.</returns>
    public int Size => size;

    /// <summary>
    /// Indexer for List. Get access to any element of list by square brackets.
    /// </summary>
    /// <param name="i">Index of element.</param>
    /// <returns>Value of element with the given index.</returns>
    public T this[int i]
    {
        get { return GetValue(i); }
        set { ChangeValue(i, value); }
    }

    public bool IsEmpty() => size == 0;

    /// <summary>
    /// Method to get value of list by its position.
    /// </summary>
    /// <param name="position">position of the element that you want to get.</param>
    /// <returns>Value of the list element in the given position.</returns>
    /// <exception cref="ArgumentOutOfRangeException">position value should to be greater than or equal to zero and less than Size.</exception>
    public T GetValue(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        return GetNodeByPosition(position).Value;
    }

    /// <summary>
    /// Method to add element to the List by position.
    /// </summary>
    /// <param name="position">position of the new list element.</param>
    /// <param name="value">value of the new lest element.</param>
    /// <exception cref="ArgumentOutOfRangeException">position value must be greater than or equal to zero and smaller than Size + 1.</exception>
    public virtual void Add(int position, T value)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (position == 0)
        {
            head = new Node(value, head);
        }
        else
        {
            var previousNode = GetNodeByPosition(position - 1);
            var newNode = new Node(value, previousNode.Next);
            previousNode.Next = newNode;
        }

        ++size;
    }

    /// <summary>
    /// Method to change list elements value by position.
    /// </summary>
    /// <param name="position">position of list element that should be changed.</param>
    /// <param name="newValue">new value for the list element.</param>
    /// <exception cref="ArgumentOutOfRangeException">position value should to be greater than or equal to zero and less than Size.</exception>
    public virtual void ChangeValue(int position, T newValue)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        GetNodeByPosition(position).Value = newValue;
    }

    /// <summary>
    /// Method to remove element by position.
    /// </summary>
    /// <param name="position">position of the element, that should to be removed.</param>
    /// <exception cref="InvalidRemoveOperationException">position of the removed element should to be greater than or equal to zero and less than Size.</exception>
    public void Remove(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new InvalidRemoveOperationException("Can't to remove element with out of range index");
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

    /// <summary>
    /// Method to get node by position.
    /// </summary>
    /// <returns>Node by position.</returns>
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

    /// <summary>
    /// List element class.
    /// </summary>
    private protected class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">new element list value.</param>
        /// <param name="next">pointer to the next list element. May to be null.</param>
        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }

        /// <summary>
        /// Gets or sets list element value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets pointer to the next list element.
        /// </summary>
        public Node? Next { get; set; }

    }
}