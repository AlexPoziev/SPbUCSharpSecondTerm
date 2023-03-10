namespace TrieTest;

using Trees;

public class Tests
{
    private Trie trie;

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [TestCase(5, "train", "trailer", "hammer", "hamon", "test")]
    [TestCase(2, "e", " e")]
    [TestCase(1, "e")]
    [TestCase(2, "etet", "ete")]
    public void AddShouldCorrectChangeSize(int expectedSize, params string[] words)
    {
        var actualAddSuccess = true;

        foreach (var element in words)
        {
            actualAddSuccess = trie.Add(element) && actualAddSuccess;
        }

        var actualSize = trie.Size;

        Assert.That(actualAddSuccess && actualSize == expectedSize);
    }

    [TestCase(1, "train", "train")]
    [TestCase(0, "")]
    public void AddExistsElementShouldReturnFalse(int expectedSize, params string[] words)
    {
        var actualAddSuccess = true;

        foreach (var element in words)
        {
            actualAddSuccess = trie.Add(element) && actualAddSuccess;
        }

        var actualSize = trie.Size;

        Assert.That(!actualAddSuccess && actualSize == expectedSize);
    }

    [TestCase("test", true, "literature", "toast", "tes", "test", "lost")]
    [TestCase("", true, "literature", "toast", "tes", "test", "lost")]
    [TestCase("tests", false, "literature", "toast", "tes", "test", "lost")]
    [TestCase("spoiler", false, "literature", "toast", "tes", "test", "lost")]
    public void ContainsAfterAddShouldReturnTrue(string word, bool expectedResult, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        Assert.That(expectedResult == trie.Contains(word));
    }

    [TestCase("test", "literature", "toast", "tes", "test", "lost")]
    [TestCase("e", "e")]
    [TestCase("spoiler", "literature", "toast", "tes", "test", "lost")]
    public void ContainsAfterRemoveShouldReturnFalse(string word, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        trie.Remove(word);

        Assert.That(!trie.Contains(word));
    }

    [TestCase("train", 5, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("trains", 5, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("trailer", 4, "train", "trains", "trailer", "hamon", "test")]
    [TestCase("e", 6, "train", "trains", "trailer", "hammer", "hamon", "test", "e")]
    [TestCase("e", 0, "e")]
    public void RemoveShouldReturnExpectedResult(string word, int expectedSize, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        var actualRemoveResult = trie.Remove(word);

        Assert.That(actualRemoveResult && !trie.Contains(word) && expectedSize == trie.Size);
    }

    [TestCase("coach", 5, "train", "trailer", "hammer", "hamon", "test")]
    [TestCase("f", 2, "e", " e")]
    public void RemoveNotExistsElementShouldReturnFalse(string word, int expectedSize, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        var actualRemoveResult = trie.Remove(word);

        Assert.That(!actualRemoveResult && !trie.Contains(word) && expectedSize == trie.Size);
    }

    [TestCase("t", 4, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("tr", 3, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("trains", 1, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("trainse", 0, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("", 6, "train", "trains", "trailer", "hammer", "hamon", "test")]
    public void HowManyStartsWithPrefixShouldReturnExpectedResult(string prefix, int expectedResult, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        var actualResult = trie.HowManyStartsWithPrefix(prefix);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase("t", "train", 3, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("tr", "train", 2, "train", "trains", "trailer", "hammer", "hamon", "test")]
    [TestCase("trains", "hammer", 1, "train", "trains", "trailer", "hammer", "hamon", "test")]
    public void HowManyStartsWithPrefixWithAfterRemoveShouldReturnExpectedResult(string prefix, string deleteWord, int expectedResult, params string[] trieElements)
    {
        foreach (var element in trieElements)
        {
            trie.Add(element);
        }

        trie.Remove(deleteWord);

        var actualResult = trie.HowManyStartsWithPrefix(prefix);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}