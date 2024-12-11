using System.ComponentModel;
using System.Linq.Expressions;

namespace linkedList
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
       static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine(linkedList.Empty());
            linkedList.Add(19);
            linkedList.Add(18);
            Console.WriteLine(linkedList.Empty());
            linkedList.DisplayList();
            Console.WriteLine(linkedList.Index());
        
        }
    }

    public class LinkedList<T>
    {
        private int Count = -1 ;
        private Node<T> head = null;
        public void Add( T data )
        {
            Node<T> newNode = new Node<T>(data, head);
            newNode.Next = head;
            head = newNode;
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
        public int Index()
        {
            return Count;
        }
        public void Clean()
        {
            //TODO
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
