namespace CoinCollectorGame;

public class MapChangeEventArgs : EventArgs
{
    public (int row, int column) ChangedCoordinates { get; }

    public char NewValue { get; }

    public MapChangeEventArgs(int row, int column, char newValue)
    {
        ChangedCoordinates = (row, column);

        NewValue = newValue;
    }
}

