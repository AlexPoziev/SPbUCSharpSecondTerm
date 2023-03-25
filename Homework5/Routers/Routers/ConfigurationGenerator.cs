namespace Routers;

public static class ConfigurationGenerator
{
    public static string[] Configurate(string[] topology)
    {
        if (topology == null)
        {
            throw new ArgumentNullException(nameof(topology));
        }

        if (!topology.Any())
        {
            throw new IncorrectTopologyFormException("Topology must be not empty");
        }

        var (links, nodesCount) = SplitTopology(topology);

        var treeMaker = new SpanningTreeCreator(links.ToArray(), nodesCount);

        var result = treeMaker.CreateMaxSpanningTree();

        return CreateTopology(result);
    }

    private static (List<Link>, int) SplitTopology(string[] topology)
    {
        if (topology == null)
        {
            throw new ArgumentNullException(nameof(topology));
        }

        var nodeSet = new HashSet<int>();

        var links = new List<Link>();

        for (int i = 0; i < topology.Length; ++i)
        {
            var currentIndex = 0;
            var firstNodeNumber = StringParseUtils.TryGetNumberUntilSign(':', ref currentIndex, topology[i]) - 1;
            if (firstNodeNumber < 0)
            {
                throw new IncorrectTopologyFormException("Router's numbers should be larger than 0");
            }

            nodeSet.Add(firstNodeNumber);

            var currentLinksSubstrings = topology[i][(currentIndex + 1)..].Split(',');

            for (int j = 0; j < currentLinksSubstrings.Length; ++j)
            {
                currentIndex = 0;

                if (currentLinksSubstrings[j][currentIndex] != ' ')
                {
                    throw new IncorrectTopologyFormException("Not enough space after ':' or ','");
                }

                ++currentIndex;
                StringParseUtils.IsInRange(currentLinksSubstrings[j], currentIndex);

                var secondNodeNumber = StringParseUtils.TryGetNumberUntilSign(' ', ref currentIndex, currentLinksSubstrings[j]) - 1;
                if (secondNodeNumber < 0)
                {
                    throw new IncorrectTopologyFormException("Router's numbers should be larger than 0");
                }

                nodeSet.Add(secondNodeNumber);

                if (secondNodeNumber == firstNodeNumber)
                {
                    throw new IncorrectTopologyFormException("Router must to connect to Another router, not itself");
                }

                ++currentIndex;
                StringParseUtils.IsInRange(currentLinksSubstrings[j], currentIndex);

                if (currentLinksSubstrings[j][currentIndex] != '(')
                {
                    throw new IncorrectTopologyFormException("Not enough '(' after second Router number");
                }

                ++currentIndex;
                StringParseUtils.IsInRange(currentLinksSubstrings[j], currentIndex);

                var linkValue = StringParseUtils.TryGetNumberUntilSign(')', ref currentIndex, currentLinksSubstrings[j]);

                if (linkValue <= 0)
                {
                    throw new IncorrectTopologyFormException("Bandwidth should be more than zero");
                }

                links.Add(new Link(firstNodeNumber, secondNodeNumber, linkValue));
            }
        }

        return (links, nodeSet.Max() + 1);
    }

    private static string[] CreateTopology(Link[] links)
    {
        var topology = new List<string>();

        var sortedLinks = links.OrderBy(it => it.FirstNodeNumber).ToArray();

        var newElement = new System.Text.StringBuilder($"{sortedLinks[0].FirstNodeNumber + 1}: {sortedLinks[0].SecondNodeNumber + 1} ({sortedLinks[0].LinkValue})");

        var result = new List<string>();
        
        for (int i = 1; i < links.Length; ++i)
        {
            if (sortedLinks[i].FirstNodeNumber == sortedLinks[i - 1].FirstNodeNumber)
            {
                newElement.Append(",");
            }
            else
            {
                result.Add(newElement.ToString());
                newElement.Clear().Append($"{sortedLinks[i].FirstNodeNumber + 1}:");
            }

            newElement.Append($" {sortedLinks[i].SecondNodeNumber + 1} ({sortedLinks[i].LinkValue})");
        }

        result.Add(newElement.ToString());

        return result.ToArray();
    }
}