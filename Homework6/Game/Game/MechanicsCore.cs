// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that append all game mechanics.
/// </summary>
public class MechanicsCore
{
    private readonly Coins coins;

    private readonly Map map;

    private (int row, int column) currentCoordinates;

    private enum Direction
    {
        Left,
        Up,
        Down,
        Right,
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MechanicsCore"/> class.
    /// </summary>
    /// <param name="map">Game map.</param>
    public MechanicsCore(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        this.map = map;

        var (first, second) = this.map.GetRandomEmptyPointCoordinates();

        this.map.SetValueInCoordinates((first, second), '@');
        currentCoordinates = (first, second);

        this.map.PrintMap();

        CursorValueChanger.Subscribe(this.map);

        coins = new (this.map);
        coins.AfterAllCoinsCollectEvent += EndGamePortal.EndGamePortalAppereance;
        coins.Subscribe(this);
        OnCoinCollect(this, new CollectCoinEventArgs(currentCoordinates));
    }

    /// <summary>
    /// Subject (or publisher) for collecting coin event(You bring a coin).
    /// </summary>
    public event EventHandler<CollectCoinEventArgs> OnCoinCollect = (sender, args) => { };

    /// <summary>
    /// Subject (of publisher) for entry game over portal.
    /// </summary>
    public event EventHandler<EventArgs> EntryGameOverPortal = (sender, args) => { };

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
    private void MoveCharacter(Direction direction)
    {
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