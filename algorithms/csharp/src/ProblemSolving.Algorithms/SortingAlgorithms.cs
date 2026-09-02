namespace ProblemSolving.Algorithms;

/// <summary>Comparison-based sorting algorithms that return a sorted copy.</summary>
public static class SortingAlgorithms
{
    public static List<T> InsertionSort<T>(
        IEnumerable<T> values,
        IComparer<T>? comparer = null)
    {
        ArgumentNullException.ThrowIfNull(values);
        comparer ??= Comparer<T>.Default;
        List<T> result = values.ToList();

        for (int index = 1; index < result.Count; index++)
        {
            T value = result[index];
            int position = index - 1;

            while (position >= 0 && comparer.Compare(result[position], value) > 0)
            {
                result[position + 1] = result[position];
                position--;
            }

            result[position + 1] = value;
        }

        return result;
    }

    public static List<T> MergeSort<T>(
        IEnumerable<T> values,
        IComparer<T>? comparer = null)
    {
        ArgumentNullException.ThrowIfNull(values);
        comparer ??= Comparer<T>.Default;
        return MergeSortRange(values.ToList(), comparer);
    }

    public static List<T> QuickSort<T>(
        IEnumerable<T> values,
        IComparer<T>? comparer = null)
    {
        ArgumentNullException.ThrowIfNull(values);
        comparer ??= Comparer<T>.Default;
        List<T> result = values.ToList();
        QuickSortRange(result, 0, result.Count - 1, comparer);
        return result;
    }

    private static List<T> MergeSortRange<T>(List<T> values, IComparer<T> comparer)
    {
        if (values.Count < 2)
        {
            return values;
        }

        int middle = values.Count / 2;
        List<T> left = MergeSortRange(values.GetRange(0, middle), comparer);
        List<T> right = MergeSortRange(
            values.GetRange(middle, values.Count - middle), comparer);
        List<T> merged = new(values.Count);
        int leftIndex = 0;
        int rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (comparer.Compare(left[leftIndex], right[rightIndex]) <= 0)
            {
                merged.Add(left[leftIndex++]);
            }
            else
            {
                merged.Add(right[rightIndex++]);
            }
        }

        merged.AddRange(left.GetRange(leftIndex, left.Count - leftIndex));
        merged.AddRange(right.GetRange(rightIndex, right.Count - rightIndex));
        return merged;
    }

    private static void QuickSortRange<T>(
        List<T> values,
        int low,
        int high,
        IComparer<T> comparer)
    {
        if (low >= high)
        {
            return;
        }

        T pivot = values[high];
        int boundary = low;
        for (int index = low; index < high; index++)
        {
            if (comparer.Compare(values[index], pivot) <= 0)
            {
                (values[boundary], values[index]) = (values[index], values[boundary]);
                boundary++;
            }
        }

        (values[boundary], values[high]) = (values[high], values[boundary]);
        QuickSortRange(values, low, boundary - 1, comparer);
        QuickSortRange(values, boundary + 1, high, comparer);
    }
}
