using System.ComponentModel;
using System;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace linkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test the LinkedList implementation
            LinkedList<int> linkedList = new LinkedList<int>();

            Console.WriteLine("Is the list empty? " + linkedList.Empty());
            linkedList.Add(19);
            linkedList.Add(18);
            Console.WriteLine("Is the list empty? " + linkedList.Empty());
            Console.WriteLine("Number of elements in the list: " + linkedList.Index());
            Console.WriteLine("List contents:");
            linkedList.DisplayList();

            linkedList.Clear();
            Console.WriteLine("\nAfter clearing the list:");
            linkedList.DisplayList();
        }
    }
}

