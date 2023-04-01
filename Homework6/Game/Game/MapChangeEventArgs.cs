namespace Game;

public class MapChangeEventArgs : EventArgs
{
    public (int, int) ChangedCoordinates { get; set; }

    public MapChangeEventArgs(int row, int column)
    {
        ChangedCoordinates = (row, column);
    }
}

