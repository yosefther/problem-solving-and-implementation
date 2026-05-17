#pragma once

#include <algorithm>
#include <cstddef>
#include <utility>
#include <vector>

namespace problem_solving {

template <typename T>
std::vector<T> insertion_sort(std::vector<T> values) {
    for (std::size_t index = 1; index < values.size(); ++index) {
        T value = std::move(values[index]);
        std::size_t position = index;
        while (position > 0 && value < values[position - 1]) {
            values[position] = std::move(values[position - 1]);
            --position;
        }
        values[position] = std::move(value);
    }
    return values;
}

template <typename T>
std::vector<T> merge_sort(std::vector<T> values) {
    if (values.size() < 2) {
        return values;
    }

    const auto middle = values.begin() + static_cast<std::ptrdiff_t>(values.size() / 2);
    std::vector<T> left(values.begin(), middle);
    std::vector<T> right(middle, values.end());
    left = merge_sort(std::move(left));
    right = merge_sort(std::move(right));

    values.clear();
    values.reserve(left.size() + right.size());
    std::merge(left.begin(), left.end(), right.begin(), right.end(),
               std::back_inserter(values));
    return values;
}

template <typename T>
void quick_sort_range(std::vector<T>& values, std::ptrdiff_t low, std::ptrdiff_t high) {
    if (low >= high) {
        return;
    }

    const T pivot = values[static_cast<std::size_t>(high)];
    std::ptrdiff_t boundary = low;
    for (std::ptrdiff_t index = low; index < high; ++index) {
        if (!(pivot < values[static_cast<std::size_t>(index)])) {
            std::swap(values[static_cast<std::size_t>(boundary)],
                      values[static_cast<std::size_t>(index)]);
            ++boundary;
        }
    }
    std::swap(values[static_cast<std::size_t>(boundary)],
              values[static_cast<std::size_t>(high)]);
    quick_sort_range(values, low, boundary - 1);
    quick_sort_range(values, boundary + 1, high);
}

template <typename T>
std::vector<T> quick_sort(std::vector<T> values) {
    if (!values.empty()) {
        quick_sort_range(values, 0, static_cast<std::ptrdiff_t>(values.size()) - 1);
    }
    return values;
}

}  // namespace problem_solving
