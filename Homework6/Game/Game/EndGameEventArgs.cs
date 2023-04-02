namespace CoinCollectorGame;

public class EndGameEventArgs : EventArgs
{
    public Map GameMap { get; }

    public (int row, int column) currentCoordinates;

    public EndGameEventArgs(Map map, (int row, int column) coordinates)
    {
        GameMap = map;
        currentCoordinates = coordinates;
    }
}