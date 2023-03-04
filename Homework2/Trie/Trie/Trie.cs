namespace Trie;

public class Trie
{
    private class Node
    {
        /// <summary>
        /// Initialize class <see cref="Node"/>.
        /// </summary>
        public Node()
        {
            next = new Dictionary<Char, Node>();
        }

        /// <summary>
        /// Collection of next nodes.
        /// </summary>
        public Dictionary<Char, Node> next;
        /// <summary>
        /// Is this element terminal for word.
        /// </summary>
        public bool isTerminal;
        /// <summary>
        /// number of words that contain this element.
        /// </summary>
        public int wordsCount;

    }

    private Trie()
    {
        head = new Node();
    }

    private Node head;

    private int _size = 1;
    public int Size {
        get
        {
            return _size;
        }
        private set
        {
            _size = value;
        }
    }

    /// <summary>
    /// Method to check is element contained in Trie.
    /// </summary>
    /// <param name="element">Еhe string to be checked to see if it is contained in.</param>
    /// <returns>true -- if Trie contains element, false -- if it doesn't.</returns>
    /// <exception cref="ArgumentNullException">element variable can't be null.</exception>
    public bool Contains(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        Node currentNode = head;

        foreach(var symbol in element)
        {
            if (!currentNode.next.ContainsKey(symbol))
            {
                return false;
            }

            currentNode = currentNode.next[symbol];
        }

        return currentNode.isTerminal;
    }

    /// <summary>
    /// Method for adding an element to a Trie.
    /// </summary>
    /// <param name="element">element, that need to be added to Trie</param>
    /// <returns>true -- it successfully added the element, false -- the element is already contained (Empty string contains in the Trie)</returns>
    /// <exception cref="ArgumentNullException">element can't be null</exception>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (Contains(element))
        {
            return false;
        }

        var currentNode = head;

        foreach(var symbol in element)
        {
            ++currentNode.wordsCount;

            if (!currentNode.next.ContainsKey(symbol))
            {
                currentNode.next.Add(symbol, new Node());
                ++_size;
            }

            currentNode = currentNode.next[symbol];
        }

        ++currentNode.wordsCount;

        return currentNode.isTerminal = true;
    }

    public bool Remove(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (element == "")
        {
            throw new ArgumentException("Can't to remove empty string", nameof(element));
        }

        if (!Contains(element))
        {
            return false;
        }

        var currentNode = head;

        for (int i = 0; i < element.Length; ++i)
        {
            --currentNode.wordsCount;

            if (currentNode.next[element[i]].wordsCount == 1)
            {
                currentNode.next.Remove(element[i]);
                return true;
            }

            currentNode = currentNode.next[element[i]];
        }

        --currentNode.wordsCount;
        currentNode.isTerminal = false;

        return true;
    }
}
