﻿namespace CoinCollectorGame;

public class Coins
{
    public event EventHandler<EndGameEventArgs> AfterAllCoinsCollectEvent = (sender, args) => { };

    private readonly Map map;

    private readonly char coin = 'o';

    private byte coinsLeft;

    public Coins(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        this.map = map;

        var random = new Random();
        coinsLeft = (byte)(random.Next(10) + 1);
    }

    public void Subscribe(MechanicsCore core)
    {
        if (core == null)
        {
            throw new ArgumentNullException(nameof(core));
        }

        core.OnCoinCollect += CollectCoin;
    }

    private void CoinCountNotifier()
    {
        Console.SetCursorPosition(0, map.Size.height + 1);
        Console.WriteLine($"Remains {coinsLeft} coins");
    }

    private void AddCoinToMap((int row, int column) coordinates)
    {
        var newCoordinates = map.GetRandomFreeAchievableSpotCoordinates(coordinates);
        map.SetValueInCoordinates(newCoordinates, coin);
    }

    private void CollectCoin(object? sender, CollectCoinEventArgs args)
    {


        --coinsLeft;
        if (coinsLeft == 0)
        {
            AfterAllCoinsCollectEvent(this, new EndGameEventArgs(map, args.Coordinates));
            if (sender != null && sender is MechanicsCore)
            {
                ((MechanicsCore)sender).OnCoinCollect -= CollectCoin;
            }

            return;
        }

        AddCoinToMap(args.Coordinates);
        CoinCountNotifier();
    }
}

