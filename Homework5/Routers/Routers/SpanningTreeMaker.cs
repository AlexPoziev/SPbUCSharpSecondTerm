// <copyright file="SpanningTreeMaker.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Class of the subgraph of an undirected connected graph.
/// It includes all the nodes along with the least possible number of links (to connect all nodes).
/// </summary>
public class SpanningTreeCreator
{
    private readonly int nodesCount;

    private readonly Link[] links;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpanningTreeCreator"/> class.
    /// </summary>
    /// <param name="links">Array of all links in graph.</param>
    /// <param name="nodesCount">Count of all nodes in graph.</param>
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

    /// <summary>
    /// Create Spanning Tree with max sum of all links values.
    /// </summary>
    /// <returns>array of new spanning tree links.</returns>
    /// <exception cref="NotConnectedGraphException">the original graph isn't connected.</exception>
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