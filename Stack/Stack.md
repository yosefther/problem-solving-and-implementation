# Stack

## What is a Stack?
A **stack** is a linear data structure that consists of items (data). The last item entered into the stack must come out first. This follows the **Last In, First Out (LIFO)** principle.

## Function Explanation
In this section, we explain the core functions implemented in the **LinkedList** class to manage a stack.

### push(value)
**Description:**
- Adds a new element to the top of the stack.
- The new element becomes the first node in the linked list.

**Steps:**
1. Create a new node with the given value.
2. Point the new node’s `next` reference to the current top.
3. Update the top pointer to the new node.

**Time Complexity:** O(1)

### peek()
**Description:**
- Returns the value of the top element without removing it.
- If the stack is empty, it should return `null` or indicate an empty stack.

**Steps:**
1. Check if the stack is empty.
2. Return the value of the top node.

**Time Complexity:** O(1)

### pop()
**Description:**
- Removes and returns the top element of the stack.
- If the stack is empty, it should return `null` or indicate an empty stack.

**Steps:**
1. Check if the stack is empty.
2. Store the top node’s value.
3. Move the top pointer to the next node.
4. Delete the old top node to free memory.
5. Return the stored value.

**Time Complexity:** O(1)

### printStack()
**Description:**
- Prints all elements of the stack from top to bottom.
- If the stack is empty, it should print a message indicating so.

**Steps:**
1. Start from the top node.
2. Traverse the linked list, printing each node’s value.
3. Stop when the last node is reached.

**Time Complexity:** O(n)

