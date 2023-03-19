namespace Tree;

/// <summary>
/// Class that holds ParseTree class utils.
/// </summary>
public static class ParseTreeUtils
{
    /// <summary>
    /// Check are paranthesis correct. Only balance, not in defined form.
    /// </summary>
    /// <returns>True -- correct, false -- incorrect.</returns>
    public static bool AreParanthesisBalanced(string expression)
    {
        int balance = 0;

        foreach (var element in expression)
        {
            if (element == '(')
            {
                ++balance;
            }
            else if (element == ')')
            {
                --balance;
                if (balance < 0)
                {
                    return false;
                }
            }
        }

        return balance == 0;
    }

    /// <summary>
    /// Method to check is char operation sign.
    /// </summary>
    /// <returns>True -- operation sign, false -- not operation sign.</returns>
    public static bool IsOperationSign(char symbol)
            => symbol == '/' || symbol == '*' || symbol == '+' || symbol == '-';
}