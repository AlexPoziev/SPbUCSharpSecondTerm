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

    private Map GameMap { get; }

    private MechanicsCore core;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    /// <param name="fileName">name of file, that contains map for the game.</param>
    public Game(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File doesn't exist", nameof(fileName));
        }

        var content = File.ReadAllLines(fileName);

        GameMap = new Map(content);

        eventLooper = new ();

        core = new (GameMap);

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