// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class of the Game, in which you can to move, collect coins and after defined number of coins
/// go in the portal and finish the game.
/// </summary>
public class Game
{
    private readonly EventLoop eventLooper;

    /// <summary>
    /// Gets core of mechanics.
    /// </summary>
    public MechanicsCore Core { get; }

    /// <summary>
    /// Gets game map.
    /// </summary>
    public Map GameMap { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with random start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName)
        : this(fileName, default, true, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with random start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName, bool withCoins)
        : this(fileName, default, true, withCoins)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with defined start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName, (int row, int column) mainCharacterStartingPosition)
        : this(fileName, mainCharacterStartingPosition, false, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with defined start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName, (int row, int column) mainCharacterStartingPosition, bool withCoins)
        : this(fileName, mainCharacterStartingPosition, false, withCoins)
    {
    }

    private Game(string fileName, (int row, int column) mainCharacterStartingPosition, bool isRandom, bool withCoins)
    {
        var content = File.ReadAllLines(fileName);

        GameMap = new Map(content);

        eventLooper = new ();

        Core = isRandom ? new (GameMap, withCoins) : new (GameMap, mainCharacterStartingPosition, withCoins);

        Core.EntryGameOverPortal += Stop;
    }

    /// <summary>
    /// Method to start a Game.
    /// </summary>
    public void Launch()
    {
        eventLooper.LeftHandler += Core.Movement.OnLeft;
        eventLooper.RightHandler += Core.Movement.OnRight;
        eventLooper.UpHandler += Core.Movement.OnUp;
        eventLooper.DownHandler += Core.Movement.OnDown;

        eventLooper.Run();
    }

    private void Stop(object? sender, EventArgs args)
    {
        eventLooper.LeftHandler -= Core.Movement.OnLeft;
        eventLooper.RightHandler -= Core.Movement.OnRight;
        eventLooper.UpHandler -= Core.Movement.OnUp;
        eventLooper.DownHandler -= Core.Movement.OnDown;

        Console.Clear();

        Console.WriteLine("""
            Congratulations!!!
            You managed to get out of a scary two-dimensional location.

            To exit, press ESCAPE key.
            """);
    }
}