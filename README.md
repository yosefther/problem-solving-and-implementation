# Data Structures and Algorithms

Implementations of fundamental data structures and algorithms for learning and
practice. The existing data structures are written in C#; the algorithm library
provides equivalent, tested implementations in Python and C++.

> This repository is intended for educational use. The implementations favor
> readability and explicit control flow over standard-library shortcuts.

## Algorithms

| Category | Algorithm | Python | C++ | Time complexity |
| --- | --- | --- | --- | --- |
| Sorting | Insertion sort | [source](algorithms/python/problem_solving_algorithms/sorting.py) | [source](algorithms/cpp/include/problem_solving_algorithms/sorting.hpp) | O(n²) |
| Sorting | Merge sort | [source](algorithms/python/problem_solving_algorithms/sorting.py) | [source](algorithms/cpp/include/problem_solving_algorithms/sorting.hpp) | O(n log n) |
| Sorting | Quicksort | [source](algorithms/python/problem_solving_algorithms/sorting.py) | [source](algorithms/cpp/include/problem_solving_algorithms/sorting.hpp) | O(n log n) average, O(n²) worst |
| Searching | Linear search | [source](algorithms/python/problem_solving_algorithms/searching.py) | [source](algorithms/cpp/include/problem_solving_algorithms/searching.hpp) | O(n) |
| Searching | Binary search | [source](algorithms/python/problem_solving_algorithms/searching.py) | [source](algorithms/cpp/include/problem_solving_algorithms/searching.hpp) | O(log n) |
| Graphs | Breadth-first search | [source](algorithms/python/problem_solving_algorithms/graphs.py) | [source](algorithms/cpp/include/problem_solving_algorithms/graphs.hpp) | O(V + E) |
| Graphs | Depth-first search | [source](algorithms/python/problem_solving_algorithms/graphs.py) | [source](algorithms/cpp/include/problem_solving_algorithms/graphs.hpp) | O(V + E) |
| Graphs | Dijkstra's shortest path | [source](algorithms/python/problem_solving_algorithms/graphs.py) | [source](algorithms/cpp/include/problem_solving_algorithms/graphs.hpp) | O((V + E) log V) |

The sorting functions return a sorted copy and leave their input unchanged.
Binary search expects an already sorted sequence. Dijkstra's algorithm accepts
non-negative edge weights and returns infinity for unreachable nodes.

## Data structures

| Structure | Implementation | Documentation |
| --- | --- | --- |
| Singly linked list | [C# source](linkedList/LinkedList.cs) | [Guide](linkedList/explain-linked-list.md) |
| Array-backed stack | [C# source](Stack/StackArrayBase.cs) | [Stack guide](Stack/Stack.md) |
| Linked-list stack | [C# source](Stack/StackLinkedListBase.cs) | [Stack guide](Stack/Stack.md) |
| Hash map | [Python source](hash/hashMap.py) | [Planned work](hash/TODO.MD) |
| Queue | C# skeletons in [`queue/`](queue/) | [Queue notes](queue/queue.md) |

The table distinguishes completed implementations from skeletons; planned data
structures are not presented as finished features.

## Repository layout

```text
algorithms/
├── cpp/
│   ├── include/problem_solving_algorithms/  # Header-only implementations
│   └── tests/                               # C++ test executable
└── python/
    ├── problem_solving_algorithms/          # Importable Python package
    └── tests/                               # unittest suite
Stack/                                       # C# stack project
linkedList/                                  # C# linked-list project
queue/                                       # C# queue project (in progress)
hash/                                        # Python hash map (in progress)
tests/                                       # C# tests
```

Algorithms are grouped under one top-level directory and then separated by
language. The older C# directories retain their current names to avoid breaking
the existing solution, project references, and namespaces.

## Run the tests

Python requires version 3.12 or newer and has no third-party dependencies:

```bash
PYTHONPATH=algorithms/python python -m unittest discover \
  -s algorithms/python/tests -v
```

Compile and run the C++ tests directly with any C++17 compiler:

```bash
g++ -std=c++17 -Wall -Wextra -Wpedantic \
  -I algorithms/cpp/include \
  algorithms/cpp/tests/algorithms_test.cpp \
  -o algorithm_tests
./algorithm_tests
```

Alternatively, use CMake:

```bash
cmake -S algorithms/cpp -B build/algorithms
cmake --build build/algorithms
ctest --test-dir build/algorithms --output-on-failure
```

Run the existing C# test project with:

```bash
dotnet test tests/tests.csproj
```

## Quick examples

Python:

```python
from problem_solving_algorithms import binary_search, merge_sort

numbers = merge_sort([8, 2, 5, 1])
position = binary_search(numbers, 5)
```

C++:

```cpp
#include <vector>
#include "problem_solving_algorithms/sorting.hpp"

auto numbers = problem_solving::merge_sort(std::vector<int>{8, 2, 5, 1});
```

## License

Licensed under the terms in [LICENSE.txt](LICENSE.txt).
