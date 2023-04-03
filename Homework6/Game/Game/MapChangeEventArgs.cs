// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that contains data for Map changing event.
/// </summary>
public class MapChangeEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapChangeEventArgs"/> class.
    /// </summary>
    /// <param name="row">row of the changed map element.</param>
    /// <param name="column">column of the changed map element.</param>
    /// <param name="newValue">new value for changed map element</param>
    public MapChangeEventArgs(int row, int column, char newValue)
    {
        ChangedCoordinates = (row, column);

        NewValue = newValue;
    }

    /// <summary>
    /// Gets coordinates of changed spot.
    /// </summary>
    public (int row, int column) ChangedCoordinates { get; }

    /// <summary>
    /// Gets new value for coordinates.
    /// </summary>
    public char NewValue { get; }
}