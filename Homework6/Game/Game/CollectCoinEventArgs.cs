namespace CoinCollectorGame;

public class CollectCoinEventArgs : EventArgs
{
    public (int row, int column) Coordinates { get; }

    public CollectCoinEventArgs((int row, int column) coordinates)
    {
        Coordinates = coordinates;
    }
}