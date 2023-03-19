namespace Tree;

public static class ParseTreeUtils
{
    public static bool IsParanthesisBalanced(string expression)
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

    public static bool IsOperationSign(char expression)
            => expression == '/' || expression == '*' || expression == '+' || expression == '-';
}

