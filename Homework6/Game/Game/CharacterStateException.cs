// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Exception to use in incorrect states of character.
/// </summary>
public class CharacterStateException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterStateException"/> class with exception message.
    /// </summary>
    public CharacterStateException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterStateException"/> class.
    /// </summary>
    public CharacterStateException()
    {
    }
}