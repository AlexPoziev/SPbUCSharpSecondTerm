namespace Lists;

public class InvalidOperationValueAlreadyExistsException : InvalidOperationException
{
    public InvalidOperationValueAlreadyExistsException()
    {
    }

    public InvalidOperationValueAlreadyExistsException(string message)
        : base(message)
    {

    }
}   

