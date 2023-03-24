namespace Routers;

public class DisjointSetUnion
{
    public DisjointSetUnion(int setSize)
    {
        if (setSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(setSize));
        }

        setUnion = new SetElement[setSize];
        for (int i = 0; i < setSize; ++i)
        {
            setUnion[i] = new SetElement(i);
        }
    }

    private readonly SetElement[] setUnion;

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

    public void UnionSets(int firstSet, int secondSet)
    {
        if (firstSet < 0 || firstSet >= setUnion.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(firstSet));
        }

        if (secondSet < 0 || secondSet >= setUnion.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(secondSet));
        }

        firstSet = FindSet(firstSet);
        secondSet = FindSet(secondSet);

        if (firstSet != secondSet)
        {
            if (setUnion[firstSet].Rank < setUnion[secondSet].Rank)
            {
                (secondSet, firstSet) = (firstSet, secondSet);
            }

            setUnion[secondSet].ParentNumber = firstSet;

            if (setUnion[firstSet].Rank == setUnion[secondSet].Rank)
            {
                ++setUnion[firstSet].Rank;
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

