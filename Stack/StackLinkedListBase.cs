using System;

namespace Stack
{
    /// <summary>
    /// A generic linked list-based stack implementation.
    /// </summary>
    internal class StackLinkedListBase<T>
    {
        private Node<T>? head; // The head node of the linked list

        /// <summary>
        /// Initializes an empty stack.
        /// </summary>
        public StackLinkedListBase()
        {
            head = null;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public T Pop()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Stack underflow: no elements to pop.");
            }

            T temp = head.Data; // Retrieve the data from the head node
            head = head.Next;   // Move the head pointer to the next node
            return temp;
        }

        /// <summary>
        /// Adds a new element to the top of the stack.
        /// </summary>
        
        public void Push(T data)
        {
            // Create a new node and make it the new head
            head = new Node<T>(data, head);
        }

        /// <summary>
        /// Prints all the elements in the stack from top to bottom.
        /// </summary>
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Empty stack");
                return;
            }

            Node<T>? current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// A generic node class used for the linked list implementation.
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }       // The data stored in the node
        public Node<T>? Next { get; set; } // Reference to the next node

        /// <summary>
        /// Default constructor for an empty node.
        /// </summary>
        public Node() { }

        /// <summary>
        /// Constructor to initialize a node with data and a reference to the next node.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        /// <param name="next">The reference to the next node.</param>
        public Node(T data, Node<T>? next)
        {
            Data = data;
            Next = next;
        }
    }
}
