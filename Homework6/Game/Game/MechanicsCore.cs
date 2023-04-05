// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that append all game mechanics.
/// </summary>
public class MechanicsCore
{
    private Coins? coins;

    private Map map;

    private (int row, int column) currentCoordinates;

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

        this.map = map;

        if (!map.IsInMapRange(mainCharacterStartingPosition))
        {
            throw new CharacterStateException("Main character starting position out of range of map size");
        }

        if (!map.IsFreePoint(mainCharacterStartingPosition))
        {
            throw new CharacterStateException("Main character starting position isn't free.");
        }

        this.map.SetValueInCoordinates(mainCharacterStartingPosition, '@');
        currentCoordinates = mainCharacterStartingPosition;

        this.map.PrintMap();

        CursorValueChanger.Subscribe(this.map);

        if (doCoins)
        {
            this.coins = new (this.map);
            this.coins.Subscribe(this);
            OnCoinCollect(this, new CollectCoinEventArgs(currentCoordinates));
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

    /// <summary>
    /// Enumeration for direction of moving.
    /// </summary>
    public enum Direction
    {
        Left,
        Up,
        Down,
        Right,
    }

    /// <summary>
    /// Observer on left move.
    /// </summary>
    public void OnLeft(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Left);
    }

    /// <summary>
    /// Observer on right move.
    /// </summary>
    public void OnRight(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Right);
    }

    /// <summary>
    /// Observer on down move.
    /// </summary>
    public void OnDown(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Down);
    }

    /// <summary>
    /// Observer on up move.
    /// </summary>
    public void OnUp(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Up);
    }

    /// <summary>
    /// Method that implement moving of character, And notify <paramref name="OnCoinCollect"/> and <paramref name="EntryGameOverPortal"/> events observers.
    /// </summary>
    public void MoveCharacter(Direction direction)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        var newCoordinates = TakeCoordinatesAfterDirectionMove(direction);

        if (!map.IsFreePoint(newCoordinates))
        {
            return;
        }

        map.SetValueInCoordinates((currentCoordinates.row, currentCoordinates.column), ' ');
        currentCoordinates = newCoordinates;
        var oldElement = map.SetValueInCoordinates((newCoordinates.row, newCoordinates.column), '@');

        if (oldElement == 'o')
        {
            OnCoinCollect(this, new CollectCoinEventArgs(currentCoordinates));
        }

        if (oldElement == '§')
        {
            EntryGameOverPortal(this, EventArgs.Empty);
        }
    }

    private (int row, int column) TakeCoordinatesAfterDirectionMove(Direction direction) =>
        direction switch
        {
            Direction.Left => (currentCoordinates.row, currentCoordinates.column - 1),
            Direction.Up => (currentCoordinates.row - 1, currentCoordinates.column),
            Direction.Down => (currentCoordinates.row + 1, currentCoordinates.column),
            Direction.Right => (currentCoordinates.row, currentCoordinates.column + 1),
            _ => throw new ArgumentException("Unexpected behaviour"),
        };
}