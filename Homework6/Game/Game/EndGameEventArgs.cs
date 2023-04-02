namespace CoinCollectorGame;

public class EndGameEventArgs : EventArgs
{
    public Map GameMap { get; }

    public EndGameEventArgs(Map map)
    {
        GameMap = map;
    }
}

