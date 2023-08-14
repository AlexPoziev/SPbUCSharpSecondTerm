using FirstTask;

namespace PalindromeTest;

public class Tests
{
    [TestCase("", true)]
    [TestCase("test", false)]
    [TestCase("lol  ", true)]
    [TestCase("Я иду с мечем судия", true)]
    public void IsPalindromeShouldReturnExpectedResult(string expression, bool expectedResult)
    {
        Assert.That(Palindrome.IsPalindrome(expression), Is.EqualTo(expectedResult));
    }
}
