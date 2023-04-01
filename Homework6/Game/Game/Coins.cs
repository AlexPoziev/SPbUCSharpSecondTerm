namespace CoinCollectorGame;

public class Coins
{
    private readonly char coin = 'o';

    private byte coinsCollected;

    private readonly Map map;

    public Coins(Map map)
    {
        this.map = map;
    }

    public void Subscribe(Game game)
    {
        game.OnCoinCollect += CollectCoin;
        AddCoinToMap();
    }

    private void AddCoinToMap()
    {
        var newCoordinates = map.GetRandomFreeSpotCoordinates();
        map.SetValueInCoordinates(newCoordinates, coin);
    }

    private void CollectCoin(object? sender, EventArgs args)
    {
        AddCoinToMap();

        ++coinsCollected;
    }
}

