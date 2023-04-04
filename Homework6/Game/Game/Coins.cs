// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class of of mechanic: They appear in random place, after collecting them all triggers end game event.
/// </summary>
public class Coins
{
    private readonly Map map;

    private readonly char coin = 'o';

    private byte coinsLeft;

    /// <summary>
    /// Initializes a new instance of the <see cref="Coins"/> class.
    /// </summary>
    /// <param name="map">game map.</param>
    public Coins(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        this.map = map;

        var random = new Random();

        coinsLeft = (byte)(random.Next(12) + 2);
    }

    /// <summary>
    /// subject of end game event (or not end) after collecting all coins.
    /// </summary>
    public event EventHandler<EndGameEventArgs> AfterAllCoinsCollectEvent = (sender, args) => { };

    /// <summary>
    /// Method to attach observer to event.
    /// </summary>
    /// <param name="core">Current game core object.</param>
    /// <exception cref="ArgumentNullException">core can't be null.</exception>
    public void Subscribe(MechanicsCore core)
    {
        if (core == null)
        {
            throw new ArgumentNullException(nameof(core));
        }

        core.OnCoinCollect += CollectCoin;

        EndGamePortal.Subscribe(this);
    }

    /// <summary>
    /// Method to detach observer to event.
    /// </summary>
    /// <param name="core">Current game core object.</param>
    /// <exception cref="ArgumentNullException">core can't be null.</exception>
    public void Unsubscribe(MechanicsCore core)
    {
        if (core == null)
        {
            throw new ArgumentNullException(nameof(core));
        }

        core.OnCoinCollect -= CollectCoin;
    }

    private void CoinCountNotifier()
    {
        Console.SetCursorPosition(0, map.Size.height + 1);
        Console.WriteLine($"Remains {coinsLeft} coins");
    }

    private void AddCoinToMap((int row, int column) coordinates)
    {
        var newCoordinates = map.GetRandomEmptyAchievablePointCoordinates(coordinates);
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
                Unsubscribe((MechanicsCore)sender);
            }

            return;
        }

        AddCoinToMap(args.Coordinates);
        CoinCountNotifier();
    }
}