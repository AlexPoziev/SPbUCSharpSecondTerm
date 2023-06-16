// <copyright file="NotConnectedGraphException.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception inform that graph isn't connected.
/// </summary>
public class DisconnectedGraphException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DisconnectedGraphException"/> class.
    /// </summary>
    public DisconnectedGraphException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DisconnectedGraphException"/> class.
    /// </summary>
    public DisconnectedGraphException(string message)
        : base(message)
    {
    }
}