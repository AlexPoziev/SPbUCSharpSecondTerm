// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that contains data for end event.
/// </summary>
public class EndGameEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndGameEventArgs"/> class.
    /// </summary>
    /// <param name="currentCoordinates">Coordinates of character in event trigger moment.</param>
    public EndGameEventArgs(Map map, (int row, int column) currentCoordinates)
    {
        GameMap = map;
        CurrentCoordinates = currentCoordinates;
    }

    /// <summary>
    /// Gets game map.
    /// </summary>
    public Map GameMap { get; }

    /// <summary>
    /// Gets coordinates of character in event trigger moment.
    /// </summary>
    public (int row, int column) CurrentCoordinates { get; }
}