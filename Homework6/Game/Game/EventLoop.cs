// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class to check user actions.
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Subject (or publisher) of left arrow press.
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    /// <summary>
    /// Subject (or publisher) of right arrow press.
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    /// <summary>
    /// Subject (or publisher) of up arrow press.
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    /// <summary>
    /// Subject (or publisher) of down arrow press.
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    /// <summary>
    /// Method to run observing actions of user.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.LeftArrow:
                    LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    DownHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        }
    }
}