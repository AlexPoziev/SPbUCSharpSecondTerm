// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Exception that notice about invalid form of form.
/// </summary>
public class InvalidMapException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidMapException"/> class with exception message.
    /// </summary>
    public InvalidMapException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidMapException"/> class.
    /// </summary>
    public InvalidMapException()
    {
    }
}