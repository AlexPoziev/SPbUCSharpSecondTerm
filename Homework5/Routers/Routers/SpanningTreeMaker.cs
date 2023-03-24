namespace Routers;

public class SpanningTreeMaker
{
    public SpanningTreeMaker(List<Link> links, int nodesCount)
    {
        if (nodesCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nodesCount));
        }


        Links = links?.OrderByDescending(it => it.LinkValue).ToList() ?? throw new ArgumentNullException(nameof(links));
        
        this.nodesCount = nodesCount;
    }

    private int nodesCount;

    private List<Link> Links { get; }

    public List<Link> MakeMaxSpanningTreeMaker()
    { }

}

