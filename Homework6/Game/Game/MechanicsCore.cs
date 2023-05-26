// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that append all game mechanics.
/// </summary>
public class MechanicsCore
{
    private readonly char coinsSign = 'o';
    private readonly char endPortalSign = '§';
    private readonly char mainCharacterSign = '@';

    public Move Movement { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MechanicsCore"/> class.
    /// </summary>
    /// <param name="doCoins">Does game need to turn on coins mechanic.</param>
    public MechanicsCore(Map map, (int row, int column) mainCharacterStartingPosition, bool doCoins)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        if (!map.IsInMapRange(mainCharacterStartingPosition))
        {
            throw new CharacterStateException("Main character starting position out of range of map size");
        }

        if (!map.IsFreePoint(mainCharacterStartingPosition))
        {
            throw new CharacterStateException("Main character starting position isn't free.");
        }

        Movement = new Move(map, mainCharacterStartingPosition);

        Movement.MoveEvent += MoveHandler;

        map.SetValueInCoordinates(mainCharacterStartingPosition, mainCharacterSign);

        map.PrintMap();

        CursorValueChanger.Subscribe(map);

        if (doCoins)
        {
            var coins = new Coins(map);
            coins.Subscribe(this);
            OnCoinCollect(this, new CollectCoinEventArgs(coinsSign, mainCharacterStartingPosition));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MechanicsCore"/> class with random start coordinates.
    /// </summary>
    /// <param name="map">Game map.</param>
    /// <param name="doCoins">Does game need to turn on coins mechanic.</param>
    public MechanicsCore(Map map, bool doCoins)
        : this(map, map.GetRandomEmptyPointCoordinates(), doCoins)
    {
    }

    /// <summary>
    /// Subject for collecting coin event(You bring a coin).
    /// </summary>
    public event EventHandler<CollectCoinEventArgs> OnCoinCollect = (sender, args) => { };

    /// <summary>
    /// Subject for entry game over portal.
    /// </summary>
    public event EventHandler<EventArgs> EntryGameOverPortal = (sender, args) => { };

    private void MoveHandler(object? sender, MoveEventArgs args)
    {
        if (args.SymbolStepOn == coinsSign)
        {
            OnCoinCollect(this, new CollectCoinEventArgs(coinsSign, args.Coordinates));
        }

        if (args.SymbolStepOn == endPortalSign)
        {
            EntryGameOverPortal(this, EventArgs.Empty);   
        }
    }
}