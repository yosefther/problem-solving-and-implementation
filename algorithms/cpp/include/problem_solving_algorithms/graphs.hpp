#pragma once

#include <algorithm>
#include <cstddef>
#include <limits>
#include <queue>
#include <stdexcept>
#include <unordered_map>
#include <unordered_set>
#include <utility>
#include <vector>

namespace problem_solving {

template <typename Node>
using Graph = std::unordered_map<Node, std::vector<Node>>;

template <typename Node>
using WeightedGraph = std::unordered_map<Node, std::vector<std::pair<Node, double>>>;

template <typename Node>
std::vector<Node> bfs(const Graph<Node>& graph, const Node& start) {
    std::vector<Node> order;
    std::unordered_set<Node> visited{start};
    std::queue<Node> pending;
    pending.push(start);

    while (!pending.empty()) {
        Node node = pending.front();
        pending.pop();
        order.push_back(node);

        const auto edges = graph.find(node);
        if (edges == graph.end()) {
            continue;
        }
        for (const Node& neighbor : edges->second) {
            if (visited.insert(neighbor).second) {
                pending.push(neighbor);
            }
        }
    }
    return order;
}

template <typename Node>
std::vector<Node> dfs(const Graph<Node>& graph, const Node& start) {
    std::vector<Node> order;
    std::unordered_set<Node> visited;
    std::vector<Node> pending{start};

    while (!pending.empty()) {
        Node node = pending.back();
        pending.pop_back();
        if (!visited.insert(node).second) {
            continue;
        }
        order.push_back(node);

        const auto edges = graph.find(node);
        if (edges != graph.end()) {
            pending.insert(pending.end(), edges->second.rbegin(), edges->second.rend());
        }
    }
    return order;
}

template <typename Node>
std::unordered_map<Node, double> dijkstra(const WeightedGraph<Node>& graph,
                                          const Node& start) {
    const double infinity = std::numeric_limits<double>::infinity();
    std::unordered_map<Node, double> distances;
    for (const auto& [node, edges] : graph) {
        distances.emplace(node, infinity);
        for (const auto& [neighbor, weight] : edges) {
            distances.emplace(neighbor, infinity);
            if (weight < 0) {
                throw std::invalid_argument("Dijkstra's algorithm requires non-negative weights");
            }
        }
    }
    distances[start] = 0.0;

    struct Entry {
        double distance;
        std::size_t sequence;
        Node node;
    };
    const auto farther = [](const Entry& left, const Entry& right) {
        if (left.distance != right.distance) {
            return left.distance > right.distance;
        }
        return left.sequence > right.sequence;
    };
    std::priority_queue<Entry, std::vector<Entry>, decltype(farther)> pending(farther);
    std::size_t sequence = 0;
    pending.push({0.0, sequence++, start});

    while (!pending.empty()) {
        const Entry current = pending.top();
        pending.pop();
        if (current.distance > distances[current.node]) {
            continue;
        }

        const auto edges = graph.find(current.node);
        if (edges == graph.end()) {
            continue;
        }
        for (const auto& [neighbor, weight] : edges->second) {
            const double candidate = current.distance + weight;
            if (candidate < distances[neighbor]) {
                distances[neighbor] = candidate;
                pending.push({candidate, sequence++, neighbor});
            }
        }
    }
    return distances;
}

}  // namespace problem_solving
