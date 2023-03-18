namespace Lists;

/// <summary>
/// Class of the Unique List collection. List withoud value duplicates.
/// </summary>
/// <typeparam name="T">Type of list elements values.</typeparam>
public class UniqueList<T> : List<T>
{
    private bool Contains(T value)
    {
        Node currentNode = head!;

        for (int i = 0; i < size; ++i)
        {
            if (value?.Equals(currentNode!.Value) ?? (value == null && currentNode!.Value == null))
            {
                return true;
            }

            currentNode = currentNode.Next!;
        }

        return false;
    }

    /// <summary>
    /// Method do add new Unique List element by position.
    /// </summary>
    /// <param name="position">position for the new Unique List element.</param>
    /// <param name="value">value for the new Unique List element.</param>
    /// <exception cref="InvalidOperationValueAlreadyExistsException">Can't to add element, that already exists.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> position should be greater than or equal to zero and less then Size + 1.</exception>
    public override void Add(int position, T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationValueAlreadyExistsException();
        }

        base.Add(position, value);
    }

    /// <summary>
    /// Method to change Unique List elements value by position.
    /// </summary>
    /// <param name="position">position of the element that should to be changed.</param>
    /// <param name="newValue">new value for the element.</param>
    /// <exception cref="InvalidOperationValueAlreadyExistsException">Can't to change element to value, that already exists.</exception>
    /// <exception cref="ArgumentOutOfRangeException">position should be greater than or equal to zero and less then Size.</exception>
    public override void ChangeValue(int position, T newValue)
    {
        if (Contains(newValue) && !GetValue(position)!.Equals(newValue))
        {
            throw new InvalidOperationValueAlreadyExistsException();
        }

        base.ChangeValue(position, newValue);
    }
}