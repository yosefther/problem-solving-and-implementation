#pragma once

#include <cstddef>
#include <vector>

namespace problem_solving {

template <typename T>
std::ptrdiff_t linear_search(const std::vector<T>& values, const T& target) {
    for (std::size_t index = 0; index < values.size(); ++index) {
        if (values[index] == target) {
            return static_cast<std::ptrdiff_t>(index);
        }
    }
    return -1;
}

template <typename T>
std::ptrdiff_t binary_search(const std::vector<T>& values, const T& target) {
    std::size_t low = 0;
    std::size_t high = values.size();

    while (low < high) {
        const std::size_t middle = low + (high - low) / 2;
        if (values[middle] == target) {
            return static_cast<std::ptrdiff_t>(middle);
        }
        if (values[middle] < target) {
            low = middle + 1;
        } else {
            high = middle;
        }
    }
    return -1;
}

}  // namespace problem_solving
