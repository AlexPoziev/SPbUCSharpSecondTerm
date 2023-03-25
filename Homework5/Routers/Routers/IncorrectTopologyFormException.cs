// <copyright file="IncorrectTopologyFormException.cs" author="Aleksey Poziev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception that inform about incorrect form of Topology string: 1: 2 (10), 3 (5).
/// </summary>
public class IncorrectTopologyFormException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectTopologyFormException"/> class.
    /// </summary>
    public IncorrectTopologyFormException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectTopologyFormException"/> class.
    /// </summary>
    public IncorrectTopologyFormException(string message)
        : base(message)
    {
    }
}