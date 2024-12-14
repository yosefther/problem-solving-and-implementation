using System;

namespace Stack
{
    /// <summary>
    /// A generic stack implementation using an array.
    /// </summary>
    class ArrayStack<T>
    {
        private T[] items; // Array to store stack elements
        private int top;   // Index of the top element

        /// <summary>
        /// Initializes an empty stack with a default capacity of 10.
        /// </summary>
        public ArrayStack()
        {
            items = new T[10]; // Default capacity
            top = -1;          // Initialize top to -1 (empty stack)
        }

        /// <summary>
        /// Adds a new element to the top of the stack.
        /// </summary>
        /// <param name="data">The element to add.</param>
        /// <exception cref="InvalidOperationException">Thrown if the stack is full.</exception>
        public void Push(T data)
        {
            if (top == items.Length - 1)
            {
                throw new InvalidOperationException("Stack overflow: no more space to push.");
            }
            items[++top] = data; // Add element and increment the top index
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool Empty()
        {
            return top == -1;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public T Pop()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Stack underflow: no elements to pop.");
            }
            return items[top--]; // Return the top element and decrement the top index
        }

        /// <summary>
        /// Displays all elements in the stack from top to bottom.
        /// </summary>
        public void Display()
        {
            if (Empty())
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            Console.WriteLine("Stack contents (top to bottom):");
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
