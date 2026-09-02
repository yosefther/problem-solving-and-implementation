namespace ProblemSolving.Algorithms;

/// <summary>Linear and binary search implementations.</summary>
public static class SearchingAlgorithms
{
    public static int LinearSearch<T>(
        IReadOnlyList<T> values,
        T target,
        IEqualityComparer<T>? comparer = null)
    {
        ArgumentNullException.ThrowIfNull(values);
        comparer ??= EqualityComparer<T>.Default;

        for (int index = 0; index < values.Count; index++)
        {
            if (comparer.Equals(values[index], target))
            {
                return index;
            }
        }

        return -1;
    }

    public static int BinarySearch<T>(
        IReadOnlyList<T> values,
        T target,
        IComparer<T>? comparer = null)
    {
        ArgumentNullException.ThrowIfNull(values);
        comparer ??= Comparer<T>.Default;
        int low = 0;
        int high = values.Count - 1;

        while (low <= high)
        {
            int middle = low + ((high - low) / 2);
            int comparison = comparer.Compare(values[middle], target);
            if (comparison == 0)
            {
                return middle;
            }

            if (comparison < 0)
            {
                low = middle + 1;
            }
            else
            {
                high = middle - 1;
            }
        }

        return -1;
    }
}
