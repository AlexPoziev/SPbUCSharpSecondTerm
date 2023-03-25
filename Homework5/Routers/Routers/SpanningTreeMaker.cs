namespace Routers;

public class SpanningTreeCreator
{
    public SpanningTreeCreator(Link[] links, int nodesCount)
    {
        if (nodesCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nodesCount));
        }

        if (links.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(links));
        }
        
        this.links = links?.OrderByDescending(it => it.LinkValue)?.ToArray() ?? throw new ArgumentNullException(nameof(links));
        
        this.nodesCount = nodesCount;
    }
    
    private readonly int nodesCount;

    private readonly Link[] links;

    public Link[] CreateMaxSpanningTree()
    {
        var dsu = new DisjointSetUnion(nodesCount);

        var result = new Link[nodesCount - 1];

        var linksCount = 0;

        var i = 0;

        while (linksCount < nodesCount - 1 && i < links.Length)
        {
            var firstSetNumber = dsu.FindSet(links[i].FirstNodeNumber);
            var secondSetNumber = dsu.FindSet(links[i].SecondNodeNumber);

            if (dsu.FindSet(links[i].FirstNodeNumber) != dsu.FindSet(links[i].SecondNodeNumber))
            {
                result[i] = links[i];
                ++linksCount;
                dsu.UnionSets(firstSetNumber, secondSetNumber);
            }

            ++i;
        }

        if (linksCount == nodesCount - 1)
        {
            return result;
        }
        else
        {
            throw new NotConnectedGraphException();
        }
    }
}

