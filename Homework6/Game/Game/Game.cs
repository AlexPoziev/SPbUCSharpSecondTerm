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

    private Map gameMap;

    private MechanicsCore core;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with random start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName)
        : this(fileName, default, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class with defined start character position.
    /// </summary>
    /// <param name="fileName">Name of the file with game map.</param>
    public Game(string fileName, (int row, int column) mainCharacterStartingPosition)
        : this(fileName, mainCharacterStartingPosition, false)
    {
    }

    private Game(string fileName, (int row, int column) mainCharacterStartingPosition, bool isRandom)
    {
        var content = File.ReadAllLines(fileName);

        gameMap = new Map(content);

        eventLooper = new ();

        core = isRandom ? new (gameMap) : new (gameMap, mainCharacterStartingPosition);

        core.EntryGameOverPortal += Stop;
    }

    /// <summary>
    /// Method to start a Game.
    /// </summary>
    public void Launch()
    {
        eventLooper.LeftHandler += core.OnLeft;
        eventLooper.RightHandler += core.OnRight;
        eventLooper.UpHandler += core.OnUp;
        eventLooper.DownHandler += core.OnDown;

        eventLooper.Run();
    }

    private void Stop(object? sender, EventArgs args)
    {
        eventLooper.LeftHandler -= core.OnLeft;
        eventLooper.RightHandler -= core.OnRight;
        eventLooper.UpHandler -= core.OnUp;
        eventLooper.DownHandler -= core.OnDown;

        Console.Clear();

        Console.WriteLine("""
            Congratulations!!!
            You managed to get out of a scary two-dimensional location.

            To exit, press ESCAPE key.
            """);
    }
}