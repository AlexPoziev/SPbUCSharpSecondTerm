namespace Routers;

public class SpanningTreeMaker
{
    public SpanningTreeMaker(List<Link> links, int nodesCount)
    {
        if (nodesCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nodesCount));
        }

        Links = new List<Link>();
        Links.AddRange(links ?? throw new ArgumentNullException(nameof(links)));
        Links = Links.OrderByDescending(it => it.LinkValue).ToList();
        
        this.nodesCount = nodesCount;
    }

    private int nodesCount;

    public List<Link> Links { get; }

    
}

