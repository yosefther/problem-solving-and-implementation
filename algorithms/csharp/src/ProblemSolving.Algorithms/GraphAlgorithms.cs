namespace ProblemSolving.Algorithms;

/// <summary>An outgoing weighted edge in an adjacency-list graph.</summary>
public readonly record struct WeightedEdge<TNode>(TNode Node, double Weight);

/// <summary>Graph traversal and shortest-path algorithms.</summary>
public static class GraphAlgorithms
{
    public static List<TNode> BreadthFirstSearch<TNode>(
        IReadOnlyDictionary<TNode, IReadOnlyCollection<TNode>> graph,
        TNode start)
        where TNode : notnull
    {
        ArgumentNullException.ThrowIfNull(graph);
        List<TNode> order = [];
        HashSet<TNode> visited = [start];
        System.Collections.Generic.Queue<TNode> pending = new();
        pending.Enqueue(start);

        while (pending.Count > 0)
        {
            TNode node = pending.Dequeue();
            order.Add(node);

            if (!graph.TryGetValue(node, out IReadOnlyCollection<TNode>? neighbors))
            {
                continue;
            }

            foreach (TNode neighbor in neighbors)
            {
                if (visited.Add(neighbor))
                {
                    pending.Enqueue(neighbor);
                }
            }
        }

        return order;
    }

    public static List<TNode> DepthFirstSearch<TNode>(
        IReadOnlyDictionary<TNode, IReadOnlyCollection<TNode>> graph,
        TNode start)
        where TNode : notnull
    {
        ArgumentNullException.ThrowIfNull(graph);
        List<TNode> order = [];
        HashSet<TNode> visited = [];
        System.Collections.Generic.Stack<TNode> pending = new();
        pending.Push(start);

        while (pending.Count > 0)
        {
            TNode node = pending.Pop();
            if (!visited.Add(node))
            {
                continue;
            }

            order.Add(node);
            if (!graph.TryGetValue(node, out IReadOnlyCollection<TNode>? neighbors))
            {
                continue;
            }

            foreach (TNode neighbor in neighbors.Reverse())
            {
                pending.Push(neighbor);
            }
        }

        return order;
    }

    public static Dictionary<TNode, double> Dijkstra<TNode>(
        IReadOnlyDictionary<TNode, IReadOnlyCollection<WeightedEdge<TNode>>> graph,
        TNode start)
        where TNode : notnull
    {
        ArgumentNullException.ThrowIfNull(graph);
        Dictionary<TNode, double> distances = [];

        foreach ((TNode node, IReadOnlyCollection<WeightedEdge<TNode>> edges) in graph)
        {
            distances.TryAdd(node, double.PositiveInfinity);
            foreach (WeightedEdge<TNode> edge in edges)
            {
                if (edge.Weight < 0)
                {
                    throw new ArgumentException(
                        "Dijkstra's algorithm requires non-negative weights.",
                        nameof(graph));
                }

                distances.TryAdd(edge.Node, double.PositiveInfinity);
            }
        }

        distances[start] = 0;
        PriorityQueue<TNode, double> pending = new();
        pending.Enqueue(start, 0);

        while (pending.TryDequeue(out TNode node, out double distance))
        {
            if (distance > distances[node])
            {
                continue;
            }

            if (!graph.TryGetValue(
                    node,
                    out IReadOnlyCollection<WeightedEdge<TNode>>? edges))
            {
                continue;
            }

            foreach (WeightedEdge<TNode> edge in edges)
            {
                double candidate = distance + edge.Weight;
                if (candidate < distances[edge.Node])
                {
                    distances[edge.Node] = candidate;
                    pending.Enqueue(edge.Node, candidate);
                }
            }
        }

        return distances;
    }
}
