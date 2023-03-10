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
    public int Size { get { return head.WordsCount; } }

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
            if (!currentNode.Next.ContainsKey(symbol))
            {
                return false;
            }

            currentNode = currentNode.Next[symbol];
        }

        return currentNode.IsTerminal || element == string.Empty;
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
            ++currentNode.WordsCount;

            if (!currentNode.Next.ContainsKey(symbol))
            {
                currentNode.Next.Add(symbol, new Node());
            }

            currentNode = currentNode.Next[symbol];
        }

        ++currentNode.WordsCount;

        return currentNode.IsTerminal = true;
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
            --currentNode.WordsCount;

            if (currentNode.Next[element[i]].WordsCount == 1)
            {
                currentNode.Next.Remove(element[i]);
                return true;
            }

            currentNode = currentNode.Next[element[i]];
        }

        --currentNode.WordsCount;
        currentNode.IsTerminal = false;

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
            if (!currentNode.Next.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.Next[symbol];
        }

        return currentNode.WordsCount;
    }

    /// <summary>
    /// Class implement Node for Trie structure.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
            Next = new Dictionary<char, Node>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether is this element terminal for word.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets number of words that contain this element.
        /// </summary>
        public int WordsCount { get; set; }

        /// <summary>
        /// Gets collection of next nodes.
        /// </summary>
        public Dictionary<char, Node> Next { get; }
    }
}