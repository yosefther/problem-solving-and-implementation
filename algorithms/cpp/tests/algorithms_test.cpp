#include <cassert>
#include <cmath>
#include <iostream>
#include <stdexcept>
#include <string>
#include <vector>

#include "problem_solving_algorithms/graphs.hpp"
#include "problem_solving_algorithms/searching.hpp"
#include "problem_solving_algorithms/sorting.hpp"

int main() {
    using namespace problem_solving;

    const std::vector<int> values{5, -1, 3, 3, 0};
    const std::vector<int> sorted{-1, 0, 3, 3, 5};
    assert(insertion_sort(values) == sorted);
    assert(merge_sort(values) == sorted);
    assert(quick_sort(values) == sorted);
    assert(linear_search(values, 3) == 2);
    assert(linear_search(values, 9) == -1);
    assert(binary_search(sorted, 3) == 2);
    assert(binary_search(sorted, 9) == -1);

    const Graph<std::string> graph{
        {"A", {"B", "C"}}, {"B", {"D"}}, {"C", {"D", "E"}},
        {"D", {}},           {"E", {}},
    };
    assert(bfs(graph, std::string{"A"}) ==
           (std::vector<std::string>{"A", "B", "C", "D", "E"}));
    assert(dfs(graph, std::string{"A"}) ==
           (std::vector<std::string>{"A", "B", "D", "C", "E"}));

    const WeightedGraph<std::string> weighted{
        {"A", {{"B", 4}, {"C", 1}}},
        {"B", {{"D", 1}}},
        {"C", {{"B", 2}, {"D", 5}}},
        {"D", {}},
        {"E", {}},
    };
    const auto distances = dijkstra(weighted, std::string{"A"});
    assert(distances.at("D") == 4);
    assert(std::isinf(distances.at("E")));

    bool rejected_negative_weight = false;
    try {
        dijkstra(WeightedGraph<std::string>{{"A", {{"B", -1}}}}, std::string{"A"});
    } catch (const std::invalid_argument&) {
        rejected_negative_weight = true;
    }
    assert(rejected_negative_weight);

    std::cout << "All C++ algorithm tests passed.\n";
}
