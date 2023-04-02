namespace CoinCollectorGame;

public static class CursorValueChanger
{
    public static void Subscribe (Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        map.OnMapChange += ChangeValue;
    }

    private static void ChangeValue(object? sender, MapChangeEventArgs e)
    {
        Console.SetCursorPosition(e.ChangedCoordinates.column, e.ChangedCoordinates.row);
        Console.Write(e.NewValue);
    }
}