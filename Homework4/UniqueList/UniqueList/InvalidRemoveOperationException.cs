namespace Lists;

/// <summary>
/// Exception throws after try to remove something that doesn't exist.
/// </summary>
public class InvalidRemoveOperationException : InvalidOperationException
{
    public InvalidRemoveOperationException()
    {
    }

    public InvalidRemoveOperationException(string message) : base(message)
    {
    }
}

