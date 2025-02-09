Queue Data Structure
A queue is a linear data structure that follows the First-In-First-Out (FIFO) principle. This means the first item added to the queue will be the first one to be removed. Think of it like a line of people waiting for a service: the person who arrives first gets served first.

Core Functions in a Linked List-Based Queue
The following functions are typically implemented in a LinkedList class to manage a queue efficiently. In this implementation:

The head of the linked list represents the front of the queue (where items are removed).

The tail of the linked list represents the rear of the queue (where items are added).

1. Insert (Enqueue)
Purpose: Adds an item to the rear of the queue.

Process:

Create a new node with the item.

If the queue is empty, set both head and tail to point to the new node.

Otherwise, link the current tail node to the new node and update tail to the new node.

Time Complexity: O(1) (constant time with a tail pointer).

Example:

python
Copy
def insert(self, item):
    new_node = Node(item)
    if self.empty():
        self.head = self.tail = new_node
    else:
        self.tail.next = new_node
        self.tail = new_node
2. Remove (Dequeue)
Purpose: Removes the item at the front of the queue (the oldest item).

Process:

Check if the queue is empty using empty(). If true, raise an error or return None.

Otherwise, retrieve the data from the head node.

Update head to point to the next node.

If the queue becomes empty after removal, update tail to None.

Time Complexity: O(1).

Example:

python
Copy
def remove(self):
    if self.empty():
        raise Exception("Queue Underflow: Cannot remove from an empty queue")
    removed_item = self.head.data
    self.head = self.head.next
    if self.head is None:
        self.tail = None
    return removed_item
3. Empty (IsEmpty)
Purpose: Checks if the queue contains no items.

Process: Return True if the head pointer is None, otherwise return False.

Time Complexity: O(1).

Example:

python
Copy
def empty(self):
    return self.head is None
Key Notes
Underflow Handling: Always check if the queue is empty before calling remove() to avoid errors.

Efficiency: Linked list-based queues ensure O(1) time complexity for both insertion and removal, making them ideal for dynamic data.

Standard Terms:

Insert → "Enqueue"

Remove → "Dequeue"
