"""Sorting algorithms that return a sorted copy of their input."""

from collections.abc import Iterable
from typing import TypeVar

T = TypeVar("T")


def insertion_sort(values: Iterable[T]) -> list[T]:
    """Sort *values* with insertion sort in O(n^2) time."""
    result = list(values)
    for index in range(1, len(result)):
        value = result[index]
        position = index - 1
        while position >= 0 and result[position] > value:
            result[position + 1] = result[position]
            position -= 1
        result[position + 1] = value
    return result


def merge_sort(values: Iterable[T]) -> list[T]:
    """Sort *values* with stable merge sort in O(n log n) time."""
    result = list(values)
    if len(result) < 2:
        return result

    middle = len(result) // 2
    left = merge_sort(result[:middle])
    right = merge_sort(result[middle:])
    merged: list[T] = []
    left_index = right_index = 0

    while left_index < len(left) and right_index < len(right):
        if left[left_index] <= right[right_index]:
            merged.append(left[left_index])
            left_index += 1
        else:
            merged.append(right[right_index])
            right_index += 1

    merged.extend(left[left_index:])
    merged.extend(right[right_index:])
    return merged


def quick_sort(values: Iterable[T]) -> list[T]:
    """Sort *values* with quicksort, returning a new list."""
    result = list(values)

    def partition(low: int, high: int) -> int:
        pivot = result[high]
        boundary = low
        for index in range(low, high):
            if result[index] <= pivot:
                result[boundary], result[index] = result[index], result[boundary]
                boundary += 1
        result[boundary], result[high] = result[high], result[boundary]
        return boundary

    def sort_range(low: int, high: int) -> None:
        if low >= high:
            return
        pivot_index = partition(low, high)
        sort_range(low, pivot_index - 1)
        sort_range(pivot_index + 1, high)

    sort_range(0, len(result) - 1)
    return result
