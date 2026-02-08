import math
import unittest

from problem_solving_algorithms import (
    bfs,
    binary_search,
    dfs,
    dijkstra,
    insertion_sort,
    linear_search,
    merge_sort,
    quick_sort,
)


class SortingTests(unittest.TestCase):
    def test_sorting_algorithms(self) -> None:
        values = [5, -1, 3, 3, 0]
        expected = [-1, 0, 3, 3, 5]
        for algorithm in (insertion_sort, merge_sort, quick_sort):
            with self.subTest(algorithm=algorithm.__name__):
                self.assertEqual(algorithm(values), expected)
                self.assertEqual(values, [5, -1, 3, 3, 0])

    def test_empty_sort(self) -> None:
        for algorithm in (insertion_sort, merge_sort, quick_sort):
            self.assertEqual(algorithm([]), [])


class SearchingTests(unittest.TestCase):
    def test_linear_search(self) -> None:
        self.assertEqual(linear_search([8, 3, 5, 3], 3), 1)
        self.assertEqual(linear_search([8, 3, 5], 9), -1)

    def test_binary_search(self) -> None:
        values = [1, 4, 7, 10, 15]
        self.assertEqual(binary_search(values, 10), 3)
        self.assertEqual(binary_search(values, 11), -1)


class GraphTests(unittest.TestCase):
    def setUp(self) -> None:
        self.graph = {
            "A": ["B", "C"],
            "B": ["D"],
            "C": ["D", "E"],
            "D": [],
            "E": [],
        }

    def test_bfs(self) -> None:
        self.assertEqual(bfs(self.graph, "A"), ["A", "B", "C", "D", "E"])

    def test_dfs(self) -> None:
        self.assertEqual(dfs(self.graph, "A"), ["A", "B", "D", "C", "E"])

    def test_dijkstra(self) -> None:
        graph = {
            "A": [("B", 4), ("C", 1)],
            "B": [("D", 1)],
            "C": [("B", 2), ("D", 5)],
            "D": [],
            "E": [],
        }
        distances = dijkstra(graph, "A")
        self.assertEqual(distances["D"], 4)
        self.assertTrue(math.isinf(distances["E"]))

    def test_dijkstra_rejects_negative_weights(self) -> None:
        with self.assertRaises(ValueError):
            dijkstra({"A": [("B", -1)]}, "A")


if __name__ == "__main__":
    unittest.main()
