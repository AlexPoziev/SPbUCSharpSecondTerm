// <copyright file="DSU.cs" author="Aleksey Poziev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Class of disjoint-set data structure, stores a collection of disjoint (non-overlapping) sets.
/// </summary>
public class DisjointSetUnion
{
    private readonly SetElement[] setUnion;

    /// <summary>
    /// Gets size of the DisjointSetUnion.
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DisjointSetUnion"/> class.
    /// </summary>
    /// <param name="unionSize">count of sets in DSU.</param>
    public DisjointSetUnion(int unionSize)
    {
        if (unionSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(unionSize));
        }

        Size = unionSize;

        setUnion = new SetElement[unionSize];
        for (int i = 0; i < unionSize; ++i)
        {
            setUnion[i] = new SetElement(i);
        }
    }

    /// <summary>
    /// Method to find the representative (also called leader) of the set that contains set with given number.
    /// </summary>
    /// <param name="setNumber">number of set, which representative is needed to find.</param>
    /// <returns>number of representative set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Set number must to be larger than zero
    /// and less than Size.</exception>
    public int FindSet(int setNumber)
    {
        if (setNumber < 0 || setNumber >= setUnion.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(setNumber));
        }

        if (setUnion[setNumber].ParentNumber == setNumber)
        {
            return setNumber;
        }

        return setUnion[setNumber].ParentNumber = FindSet(setUnion[setNumber].ParentNumber);
    }

    /// <summary>
    /// Merges the two specified sets.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">firstSetNumber and secondSetNumber
    /// must be larger than zero and less than Size</exception>
    public void UnionSets(int firstSetNumber, int secondSetNumber)
    {
        if (firstSetNumber < 0 || firstSetNumber >= setUnion.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(firstSetNumber));
        }

        if (secondSetNumber < 0 || secondSetNumber >= setUnion.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(secondSetNumber));
        }

        firstSetNumber = FindSet(firstSetNumber);
        secondSetNumber = FindSet(secondSetNumber);

        if (firstSetNumber != secondSetNumber)
        {
            if (setUnion[firstSetNumber].Rank < setUnion[secondSetNumber].Rank)
            {
                (secondSetNumber, firstSetNumber) = (firstSetNumber, secondSetNumber);
            }

            setUnion[secondSetNumber].ParentNumber = firstSetNumber;

            if (setUnion[firstSetNumber].Rank == setUnion[secondSetNumber].Rank)
            {
                ++setUnion[firstSetNumber].Rank;
            }
        }
    }

    private class SetElement
    {
        public SetElement(int parentNumber)
        {
            ParentNumber = parentNumber;
        }

        public int Rank { get; set; } = 0;

        public int ParentNumber { get; set; }
    }
}