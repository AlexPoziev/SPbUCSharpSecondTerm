// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that perform moving in 2-dimensional map.
/// </summary>
public class Move
{
    private Map map;

    private (int row, int column) currentCoordinates;

    /// <summary>
    /// Event on any move of character.
    /// </summary>
    public event EventHandler<MoveEventArgs> MoveEvent = (sender, args) => { };

    /// <summary>
    /// Initializes a new instance of the <see cref="Move"/> class.
    /// </summary>
    public Move(Map map, (int row, int column) currentCoordinates)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        this.map = map;

        this.currentCoordinates = currentCoordinates;
    }

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

        MoveEvent(this, new MoveEventArgs(oldElement, currentCoordinates));
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