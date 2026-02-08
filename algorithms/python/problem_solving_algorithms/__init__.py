"""Reference implementations of common algorithms."""

from .graphs import bfs, dfs, dijkstra
from .searching import binary_search, linear_search
from .sorting import insertion_sort, merge_sort, quick_sort

__all__ = [
    "bfs",
    "binary_search",
    "dfs",
    "dijkstra",
    "insertion_sort",
    "linear_search",
    "merge_sort",
    "quick_sort",
]
