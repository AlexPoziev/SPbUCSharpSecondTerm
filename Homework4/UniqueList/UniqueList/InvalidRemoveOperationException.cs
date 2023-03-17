namespace UniqueList;

public class InvalidRemoveOperationException : InvalidOperationException
{

    public InvalidRemoveOperationException()
    {
    }


    public InvalidRemoveOperationException(string message) : base(message)
    {
    }
}

