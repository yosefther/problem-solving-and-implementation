using ProblemSolving.Algorithms;
using Xunit;

namespace DataStructureTests.Unit;

public class SortingAlgorithmTests
{
    private static readonly int[] Values = [5, -1, 3, 3, 0];
    private static readonly int[] Expected = [-1, 0, 3, 3, 5];

    [Fact]
    public void SortingAlgorithms_ReturnSortedCopy()
    {
        Assert.Equal(Expected, SortingAlgorithms.InsertionSort(Values));
        Assert.Equal(Expected, SortingAlgorithms.MergeSort(Values));
        Assert.Equal(Expected, SortingAlgorithms.QuickSort(Values));
        Assert.Equal(new[] { 5, -1, 3, 3, 0 }, Values);
    }

    [Fact]
    public void SortingAlgorithms_HandleEmptyInput()
    {
        Assert.Empty(SortingAlgorithms.InsertionSort(Array.Empty<int>()));
        Assert.Empty(SortingAlgorithms.MergeSort(Array.Empty<int>()));
        Assert.Empty(SortingAlgorithms.QuickSort(Array.Empty<int>()));
    }
}

public class SearchingAlgorithmTests
{
    [Fact]
    public void LinearSearch_ReturnsFirstMatchOrMinusOne()
    {
        Assert.Equal(1, SearchingAlgorithms.LinearSearch([8, 3, 5, 3], 3));
        Assert.Equal(-1, SearchingAlgorithms.LinearSearch([8, 3, 5], 9));
    }

    [Fact]
    public void BinarySearch_ReturnsMatchOrMinusOne()
    {
        int[] values = [1, 4, 7, 10, 15];
        Assert.Equal(3, SearchingAlgorithms.BinarySearch(values, 10));
        Assert.Equal(-1, SearchingAlgorithms.BinarySearch(values, 11));
    }
}

public class GraphAlgorithmTests
{
    private readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> graph =
        new Dictionary<string, IReadOnlyCollection<string>>
        {
            ["A"] = ["B", "C"],
            ["B"] = ["D"],
            ["C"] = ["D", "E"],
            ["D"] = [],
            ["E"] = [],
        };

    [Fact]
    public void BreadthFirstSearch_ReturnsLevelOrder()
    {
        Assert.Equal(
            new[] { "A", "B", "C", "D", "E" },
            GraphAlgorithms.BreadthFirstSearch(graph, "A"));
    }

    [Fact]
    public void DepthFirstSearch_ReturnsDepthFirstOrder()
    {
        Assert.Equal(
            new[] { "A", "B", "D", "C", "E" },
            GraphAlgorithms.DepthFirstSearch(graph, "A"));
    }

    [Fact]
    public void Dijkstra_ReturnsShortestDistancesAndInfinityForUnreachableNodes()
    {
        IReadOnlyDictionary<string, IReadOnlyCollection<WeightedEdge<string>>> weighted =
            new Dictionary<string, IReadOnlyCollection<WeightedEdge<string>>>
            {
                ["A"] = [new("B", 4), new("C", 1)],
                ["B"] = [new("D", 1)],
                ["C"] = [new("B", 2), new("D", 5)],
                ["D"] = [],
                ["E"] = [],
            };

        Dictionary<string, double> distances = GraphAlgorithms.Dijkstra(weighted, "A");

        Assert.Equal(4, distances["D"]);
        Assert.True(double.IsPositiveInfinity(distances["E"]));
    }

    [Fact]
    public void Dijkstra_RejectsNegativeWeights()
    {
        IReadOnlyDictionary<string, IReadOnlyCollection<WeightedEdge<string>>> graph =
            new Dictionary<string, IReadOnlyCollection<WeightedEdge<string>>>
            {
                ["A"] = [new("B", -1)],
            };

        Assert.Throws<ArgumentException>(() => GraphAlgorithms.Dijkstra(graph, "A"));
    }
}
