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
        head = new Node();
    }

    /// <summary>
    /// Gets size of Trie, count of elements in Trie, doesn't include empty string.
    /// </summary>
    public int Size
    {
        get
        {
            return head.wordsCount;
        }
        private set { }
    }

    /// <summary>
    /// Class implement Node for Trie structure.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Is this element terminal for word.
        /// </summary>
        public bool isTerminal = false;

        /// <summary>
        /// number of words that contain this element.
        /// </summary>
        public int wordsCount;

        /// <summary>
        /// Collection of next nodes.
        /// </summary>
        public Dictionary<char, Node> next;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
            next = new Dictionary<char, Node>();
        }
    }

    /// <summary>
    /// Method to check is element contained in Trie.
    /// </summary>
    /// <param name="element">Еhe string to be checked to see if it is contained in.</param>
    /// <returns>true -- if Trie contains element, false -- if it doesn't (Empty string contained in the Trie) .</returns>
    /// <exception cref="ArgumentNullException">element variable can't be null.</exception>
    public bool Contains(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        Node currentNode = head;

        foreach (var symbol in element)
        {
            if (!currentNode.next.ContainsKey(symbol))
            {
                return false;
            }

            currentNode = currentNode.next[symbol];
        }

        return currentNode.isTerminal || element == string.Empty;
    }

    /// <summary>
    /// Method for adding an element to a Trie.
    /// </summary>
    /// <param name="element">element, that need to be added to Trie.</param>
    /// <returns>true -- it successfully added the element, false -- the element is already contained (Empty string contained in the Trie).</returns>
    /// <exception cref="ArgumentNullException">element can't be null.</exception>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (element == string.Empty)
        {
            return false;
        }

        if (Contains(element))
        {
            return false;
        }

        var currentNode = head;

        foreach (var symbol in element)
        {
            ++currentNode.wordsCount;

            if (!currentNode.next.ContainsKey(symbol))
            {
                currentNode.next.Add(symbol, new Node());
            }

            currentNode = currentNode.next[symbol];
        }

        ++currentNode.wordsCount;

        return currentNode.isTerminal = true;
    }

    /// <summary>
    /// Method to remove element from Trie.
    /// </summary>
    /// <param name="element">element that will be deleted.</param>
    /// <returns>true -- if <see cref="element"/> really was in Trie, false -- if Trie doesn't contain <see cref="element"/> .</returns>
    /// <exception cref="ArgumentNullException">element can't be null.</exception>
    /// <exception cref="ArgumentException">can't delete empty string.</exception>
    public bool Remove(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null");
        }

        if (element == string.Empty)
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

    /// <summary>
    /// Method that returns how many elements of Trie starts with prefix.
    /// </summary>
    /// <param name="prefix">prefix with which the number should start.</param>
    /// <returns>Count of elements Trie which start with prefix. Empty string will return count of all words in Trie.</returns>
    /// <exception cref="ArgumentNullException">prefix can't be null.</exception>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix == null)
        {
            throw new ArgumentNullException(nameof(prefix), "Can't be null");
        }

        Node currentNode = head;

        foreach (var symbol in prefix)
        {
            if (!currentNode.next.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.next[symbol];
        }

        return currentNode.wordsCount;
    }
}