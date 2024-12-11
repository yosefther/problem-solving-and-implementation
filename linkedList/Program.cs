using System.ComponentModel;
using System.Linq.Expressions;

namespace linkedList
{
    public class Program
    {

        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine(linkedList.Empty());
            linkedList.Add(19);
            linkedList.Add(18);
            linkedList.Add(17);
            linkedList.Add(16);
            linkedList.Add(15);
            Console.WriteLine(linkedList.Empty());
            linkedList.DisplayList();
        }
    }

    public class LinkedList<T>
    {
        private int Count = -1 ;
        private Node<T> head = null;
        public void Add( T data )
        {
            Node<T> foo = new Node<T>(data, head);
            foo.Next = head;
            head = foo;
            Count = Count + 1;
        }
        public bool Empty(){
            if (Count == -1)
                return true;
            else
                return false;
        }
        public void DisplayList()
        {
            Node<T> c = head;
            while ( c != null)
            {
                Console.WriteLine(c.Data);
                c = c.Next;
            }
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
