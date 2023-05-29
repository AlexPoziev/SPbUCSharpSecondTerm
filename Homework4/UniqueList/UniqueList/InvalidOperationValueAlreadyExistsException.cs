namespace Lists;

/// <summary>
/// Exception throws after try to add element that already exists.
/// </summary>
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

