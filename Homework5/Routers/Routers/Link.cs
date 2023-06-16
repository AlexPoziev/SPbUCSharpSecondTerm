// <copyright file="Link.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Class of entity that connect nodes in graph.
/// </summary>
/// <param name="LinkValue">Value that link has.</param>
public record Link(int FirstNodeNumber, int SecondNodeNumber, int LinkValue);