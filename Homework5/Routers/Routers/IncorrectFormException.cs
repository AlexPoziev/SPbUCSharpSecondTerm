// <copyright file="IncorrectFormException.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception that inform about incorrect form of entry data.
/// </summary>
public class IncorrectFormException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectFormException"/> class.
    /// </summary>
    public IncorrectFormException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectFormException"/> class.
    /// </summary>
    public IncorrectFormException(string message)
        : base(message)
    {
    }
}