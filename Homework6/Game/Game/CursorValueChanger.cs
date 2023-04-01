namespace CoinCollectorGame;

public class CursorValueChanger
{
    public void Subscribe (Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        map.OnMapChange += ChangeValue;
    }

    private void ChangeValue(object? sender, MapChangeEventArgs e)
    {
        Console.SetCursorPosition(e.ChangedCoordinates.column, e.ChangedCoordinates.row);
        Console.Write(e.NewValue);
    }
}

