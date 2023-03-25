namespace Routers;

public class IncorrectTopologyFormException : Exception
{
    public IncorrectTopologyFormException()
    {
    }

    public IncorrectTopologyFormException(string message)
        : base(message)
    {
    }
}

