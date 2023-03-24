namespace Routers;

public class NotConnectedGraphException : Exception
{
    public NotConnectedGraphException()
    {
    }

    public NotConnectedGraphException(string message)
        : base(message)
    {
    }
}

