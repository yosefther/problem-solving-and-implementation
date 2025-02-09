# Queue Data Structure
A **queue** is a linear data structure that adheres to the First-In-First-Out (FIFO) principle. This means the first element added to the queue is always the first to be removed, analogous to a real-world waiting line.

## Core Operations
In a linked list-based queue implementation:

The head of the linked list represents the front (removal point).

The tail of the linked list represents the rear (insertion point).

## Enqueue (Insert)
Purpose: Add an item to the rear of the queue.

## Process:

Create a new node for the item.

If the queue is empty, set both head and tail to the new node.

For a non-empty queue, link the new node to the current tail and update the tail pointer.

Time Complexity: O(1) (constant time due to direct tail access).

## Dequeue (Remove)
Purpose: Remove the item at the front of the queue.

### Process:

Verify the queue is not empty.

Retrieve the data from the head node.

Update the head pointer to the next node.

If the queue becomes empty after removal, reset the tail pointer.

Time Complexity: O(1).

## IsEmpty (Empty Check)
Purpose: Determine if the queue contains no elements.

### Process: Check if the head pointer is null (or None).

Time Complexity: O(1).

Key Notes
Underflow Handling: Always check IsEmpty before calling Dequeue to prevent errors.

Efficiency: Linked list-based queues achieve O(1) time complexity for both insertion and removal.

Terminology:

Enqueue = Insert (add to rear)

Dequeue = Remove (take from front)

Use Cases: Task scheduling, buffering, and breadth-first search (BFS) algorithms.
