"""Linear and binary search implementations."""

from collections.abc import Sequence
from typing import TypeVar

T = TypeVar("T")


def linear_search(values: Sequence[T], target: T) -> int:
    """Return the first index of *target*, or -1 when it is absent."""
    for index, value in enumerate(values):
        if value == target:
            return index
    return -1


def binary_search(values: Sequence[T], target: T) -> int:
    """Return an index of *target* in sorted *values*, or -1."""
    low = 0
    high = len(values) - 1

    while low <= high:
        middle = low + (high - low) // 2
        if values[middle] == target:
            return middle
        if values[middle] < target:
            low = middle + 1
        else:
            high = middle - 1
    return -1
