namespace Lists;

public class UniqueList<T> : List<T>
{
    private bool Contains(T value)
    {
        Node currentNode = head!;

        for (int i = 0; i < size; ++i)
        {
            if (currentNode!.Value?.Equals(value) ?? false)
            {
                return true;
            }

            currentNode = currentNode.Next!;
        }

        return false;
    }

    public override void Add(int position, T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationValueAlreadyExistsException();
        }

        base.Add(position, value);
    }

    public override void ChangeValue(int position, T newValue)
    {
        if (Contains(newValue) && !GetValue(position)!.Equals(newValue))
        {
            throw new InvalidOperationValueAlreadyExistsException();
        }

        base.ChangeValue(position, newValue);
    }
}