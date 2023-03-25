// <copyright file="Link.cs" author="Aleksey Poziev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// 
/// </summary>
/// <param name="FirstNodeNumber"></param>
/// <param name="SecondNodeNumber"></param>
/// <param name="LinkValue"></param>
public record Link(int FirstNodeNumber, int SecondNodeNumber, int LinkValue);