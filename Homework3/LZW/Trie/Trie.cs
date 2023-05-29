namespace Trees;

/// <summary>
/// Class implements Trie structure.
/// </summary>
public class Trie
{
    /// <summary>
    /// main node of Trie, all methods start from it.
    /// </summary>
    private readonly Node head;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        head = new Node(-1);
    }

    /// <summary>
    /// Gets size of Trie, count of elements in Trie, doesn't include empty array.
    /// </summary>
    public int Size { get { return head.BytesCount; } }

    /// <summary>
    /// Method to check is element contained in Trie.
    /// </summary>
    /// <param name="element">The array to be checked to see if it is contained in.</param>
    /// <returns>true -- if Trie contains element, false -- if it doesn't (Empty array contained in the Trie) .</returns>
    /// <exception cref="ArgumentNullException">element variable can't be null.</exception>
    public bool Contains(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        Node currentNode = head;

        foreach (var bytes in element)
        {
            if (!currentNode.Next.ContainsKey(bytes))
            {
                return false;
            }

            currentNode = currentNode.Next[bytes];
        }

        return currentNode.IsTerminal || !element.Any();
    }

    /// <summary>
    /// Method for adding an element to a Trie.
    /// </summary>
    /// <param name="element">element, that need to be added to Trie.</param>
    /// <returns>true -- it successfully added the element, false -- the element is already contained (Empty array contained in the Trie).</returns>
    /// <exception cref="ArgumentNullException">element can't be null.</exception>
    public bool Add(List<byte> element, int value)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (!element.Any())
        {
            return false;
        }

        if (Contains(element))
        {
            return false;
        }

        var currentNode = head;

        foreach (var bytes in element)
        {
            ++currentNode.BytesCount;

            if (!currentNode.Next.ContainsKey(bytes))
            {
                currentNode.Next.Add(bytes, new Node(value));
            }

            currentNode = currentNode.Next[bytes];
        }

        ++currentNode.BytesCount;

        return currentNode.IsTerminal = true;
    }

    /// <summary>
    /// Method to remove element from Trie.
    /// </summary>
    /// <param name="element">element that will be deleted.</param>
    /// <returns>true -- if <see cref="element"/> really was in Trie, false -- if Trie doesn't contain <see cref="element"/> .</returns>
    /// <exception cref="ArgumentNullException">element can't be null.</exception>
    /// <exception cref="ArgumentException">can't delete empty array.</exception>
    public bool Remove(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (!element.Any())
        {
            throw new ArgumentException("Can't to remove empty string", nameof(element));
        }

        if (!Contains(element))
        {
            return false;
        }

        var currentNode = head;

        for (int i = 0; i < element.Count; ++i)
        {
            --currentNode.BytesCount;

            if (currentNode.Next[element[i]].BytesCount == 1)
            {
                currentNode.Next.Remove(element[i]);
                return true;
            }

            currentNode = currentNode.Next[element[i]];
        }

        --currentNode.BytesCount;
        currentNode.IsTerminal = false;

        return true;
    }

    /// <summary>
    /// Method that returns how many elements of Trie starts with prefix.
    /// </summary>
    /// <param name="prefix">prefix with which the number should start.</param>
    /// <returns>Count of elements Trie which start with prefix. Empty array will return count of all words in Trie.</returns>
    /// <exception cref="ArgumentNullException">prefix can't be null.</exception>
    public int HowManyStartsWithPrefix(List<byte> prefix)
    {
        if (prefix == null)
        {
            throw new ArgumentNullException(nameof(prefix), "Can't be null");
        }

        Node currentNode = head;

        foreach (var symbol in prefix)
        {
            if (!currentNode.Next.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.Next[symbol];
        }

        return currentNode.BytesCount;
    }

    /// <summary>
    /// Method to get value of byte array
    /// </summary>
    /// <returns>returns -1 if no word in Trie, else value of word </returns>
    /// <exception cref="ArgumentNullException">byte array can't be null</exception>
    public int GetValueOfElement(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        Node currentNode = head;

        for (var i = 0; i < element.Count; ++i)
        {
            if (!currentNode.Next.ContainsKey(element[i]))
            {
                return -1;
            }

            currentNode = currentNode.Next[element[i]];
        }

        return currentNode.Value;
    }

    /// <summary>
    /// Class implement Node for Trie structure.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node(int value)
        {
            Next = new Dictionary<byte, Node>();
            Value = value;
        }

        /// <summary>
        /// Gets a value included in Node
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Gets or sets a value indicating whether is this element terminal for byte array.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets number of words that contain this element.
        /// </summary>
        public int BytesCount { get; set; }

        /// <summary>
        /// Gets collection of next nodes.
        /// </summary>
        public Dictionary<byte, Node> Next { get; }
    }
}