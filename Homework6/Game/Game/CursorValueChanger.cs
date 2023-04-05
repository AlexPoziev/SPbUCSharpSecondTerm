// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class observer for map value changer.
/// </summary>
public static class CursorValueChanger
{
    /// <summary>
    /// Method to attach observer to event.
    /// </summary>
    /// <exception cref="ArgumentNullException">map can't be null.</exception>
    public static void Subscribe(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        map.OnMapChange += ChangeValue;
    }

    /// <summary>
    /// Method to detach observe method to event.
    /// </summary>
    /// <exception cref="ArgumentNullException">map can't be null.</exception>
    public static void Unsubscribe(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        map.OnMapChange -= ChangeValue;
    }

    private static void ChangeValue(object? sender, MapChangeEventArgs e)
    {
        Console.SetCursorPosition(e.ChangedCoordinates.column, e.ChangedCoordinates.row);
        Console.Write(e.NewValue);
    }
}