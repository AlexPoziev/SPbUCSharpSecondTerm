// <copyright file="NotConnectedGraphException.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception inform that graph isn't connected.
/// </summary>
public class NotConnectedGraphException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotConnectedGraphException"/> class.
    /// </summary>
    public NotConnectedGraphException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotConnectedGraphException"/> class.
    /// </summary>
    public NotConnectedGraphException(string message)
        : base(message)
    {
    }
}