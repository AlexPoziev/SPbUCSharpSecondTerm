// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// class for end games methods.
/// </summary>
public static class EndGamePortal
{
    /// <summary>
    /// Method to attach observe method to event.
    /// </summary>
    /// <exception cref="ArgumentNullException">map can't be null.</exception>
    public static void Subscribe(Coins coins)
    {
        if (coins == null)
        {
            throw new ArgumentNullException(nameof(coins));
        }

        coins.AfterAllCoinsCollectEvent += EndGamePortalAppereance;
    }

    /// <summary>
    /// Method to detach observe method to event.
    /// </summary>
    /// <exception cref="ArgumentNullException">map can't be null.</exception>
    public static void Unsubscribe(Coins coins)
    {
        if (coins == null)
        {
            throw new ArgumentNullException(nameof(coins));
        }

        coins.AfterAllCoinsCollectEvent -= EndGamePortalAppereance;
    }

    /// <summary>
    /// Observer method, to initialize end game portal.
    /// </summary>
    private static void EndGamePortalAppereance(object? sender, EndGameEventArgs args)
    {
        const char portalSign = '§';

        args.GameMap.AddFreePointSign(portalSign);

        (int row, int column) = args.GameMap.GetRandomEmptyAchievablePointCoordinates(args.CurrentCoordinates);

        args.GameMap.SetValueInCoordinates((row, column), portalSign);

        Console.SetCursorPosition(0, args.GameMap.Size.height + 1);
        Console.WriteLine($"You collected All Coins!!! Go to the End Portal '§'");
    }
}