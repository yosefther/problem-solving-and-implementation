"""Traversal and shortest-path algorithms for adjacency-list graphs."""

from collections import deque
from collections.abc import Hashable, Mapping, Sequence
from heapq import heappop, heappush
from itertools import count
from math import inf
from typing import TypeVar

Node = TypeVar("Node", bound=Hashable)


def bfs(graph: Mapping[Node, Sequence[Node]], start: Node) -> list[Node]:
    """Return nodes in breadth-first traversal order from *start*."""
    visited = {start}
    pending = deque([start])
    order: list[Node] = []

    while pending:
        node = pending.popleft()
        order.append(node)
        for neighbor in graph.get(node, ()):
            if neighbor not in visited:
                visited.add(neighbor)
                pending.append(neighbor)
    return order


def dfs(graph: Mapping[Node, Sequence[Node]], start: Node) -> list[Node]:
    """Return nodes in iterative depth-first traversal order from *start*."""
    visited: set[Node] = set()
    pending = [start]
    order: list[Node] = []

    while pending:
        node = pending.pop()
        if node in visited:
            continue
        visited.add(node)
        order.append(node)
        pending.extend(reversed(graph.get(node, ())))
    return order


def dijkstra(
    graph: Mapping[Node, Sequence[tuple[Node, float]]], start: Node
) -> dict[Node, float]:
    """Return shortest distances from *start* in a non-negative weighted graph."""
    nodes = set(graph)
    for edges in graph.values():
        nodes.update(neighbor for neighbor, _ in edges)

    distances = {node: inf for node in nodes}
    distances[start] = 0.0
    sequence = count()
    pending: list[tuple[float, int, Node]] = [(0.0, next(sequence), start)]

    while pending:
        distance, _, node = heappop(pending)
        if distance > distances[node]:
            continue
        for neighbor, weight in graph.get(node, ()):
            if weight < 0:
                raise ValueError("Dijkstra's algorithm requires non-negative weights")
            candidate = distance + weight
            if candidate < distances[neighbor]:
                distances[neighbor] = candidate
                heappush(pending, (candidate, next(sequence), neighbor))
    return distances
