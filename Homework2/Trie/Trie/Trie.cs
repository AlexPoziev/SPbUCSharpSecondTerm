namespace Trie;

public class Trie
{
    private class Node
    {
        /// <summary>
        /// Initialize class <see cref="Node"/>
        /// </summary>
        public Node()
        {
            next = new Dictionary<Char, Node>();
        }

        /// <summary>
        /// Collection of next nodes
        /// </summary>
        public Dictionary<Char, Node> next;
        /// <summary>
        /// Is this element terminal for word
        /// </summary>
        public bool isTerminal;
        /// <summary>
        /// number of words that contain this element
        /// </summary>
        public int wordsCount;

    }

    private Trie()
    {
        head = new Node();
    }

    private Node head;

    public int Size { get; set; }

    public bool Contains(string element)
    {
        Node currentNode = head;

        foreach(var symbol in element)
        {
            currentNode = currentNode.next[symbol];
            if (currentNode == null)
            {
                return false;
            }
        }

        return true;
    }
}

