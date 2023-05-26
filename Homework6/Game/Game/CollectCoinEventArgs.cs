// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that contains data for collect coin event.
/// </summary>
public class CollectCoinEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MoveEventArgs"/> class.
    /// </summary>
    /// <param name="coordinates">coordinates of current characters point.</param>
    public CollectCoinEventArgs(char symbol, (int row, int column) coordinates)
    {
        CoinSymbol = symbol;
        Coordinates = coordinates;
    }

    public char CoinSymbol { get; }

    /// <summary>
    /// Gets coordinates of current characters point.
    /// </summary>
    public (int row, int column) Coordinates { get; }
}