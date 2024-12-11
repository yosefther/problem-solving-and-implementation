using System.ComponentModel;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace linkedList
{
    public class Program
    {
       static void Main(string[] args)
        {
            //test 
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine(linkedList.Empty());
            linkedList.Add(19);
            linkedList.Add(18);
            Console.WriteLine(linkedList.Empty());
            Console.WriteLine(linkedList.Index());
            linkedList.DisplayList();
            linkedList.Clean();
            linkedList.DisplayList();
        }
    }

    public class LinkedList<T>
    {
        private int Count = 0 ;
        private Node<T> head = null;
        private Node<T> tail;

        //This method is used to add a new node or value at the start of the LinkedList.
        public void Add( T data )
        {
            Node<T> newNode = new Node<T>(data, head);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            Count++;
        }
        //This method is used to check whether the LinkedList is empty.
        public bool Empty(){
            if (Count == 0)
                return true;
            else
                return false;
        }
        //This method is used to traverse and print all elements in the LinkedList.
        public void DisplayList()
        {
            Node<T> c = head;
            if (c == null)
            {
                Console.WriteLine("Empty list");
            }
            else
            {
                while (c != null)
                {
                    Console.WriteLine(c.Data);
                    c = c.Next;

                }
            }
        }
        // This method to show index number 
        public int Index()
        {
            return Count;
        }
        //This method is used to remove all nodes from the LinkedList.
        public void Clean()
        {
            head = tail = null;
        }

    }
    public class Node<T>
    {
       public T Data { get; set; }
       public Node<T> Next { get; set; }
        public Node(T data , Node<T> next){
            this.Data = data;
            this.Next = next;
        }
    }
}
