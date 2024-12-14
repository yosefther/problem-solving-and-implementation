using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedList
{
    /// <summary>
    /// A generic singly linked list implementation.
    /// </summary>
    public class LinkedList<T>
    {
        private int count;         // Tracks the number of nodes in the list
        private Node<T>? head;     // The first node in the list
        private Node<T>? tail;     // The last node in the list

        /// <summary>
        /// Adds a new node at the start of the list.
        /// </summary>
        /// <param name="data">The data to be stored in the node.</param>
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data, head);

            if (head == null)
            {
                // If the list is empty, set both head and tail to the new node
                head = tail = newNode;
            }
            else
            {
                // Otherwise, make the new node the new head
                newNode.Next = head;
                head = newNode;
            }

            count++; // Increment the count of nodes
        }

        /// <summary>
        /// Checks whether the linked list is empty.
        /// </summary>
        /// <returns>True if the list is empty, otherwise false.</returns>
        public bool Empty() => count == 0;

        /// <summary>
        /// Displays all elements in the linked list.
        /// </summary>
        public void DisplayList()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T>? current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns the number of elements in the linked list.
        /// </summary>
        /// <returns>The count of nodes in the list.</returns>
        public int Index() => count;

        /// <summary>
        /// Removes all nodes from the linked list.
        /// </summary>
        public void Clean()
        {
            head = tail = null; // Remove all references to nodes
            count = 0;         // Reset the count
        }
    }

    /// <summary>
    /// A generic node class for the linked list.
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }       // The data stored in the node
        public Node<T>? Next { get; set; } // Reference to the next node

        /// <summary>
        /// Initializes a new node with data and a reference to the next node.
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
