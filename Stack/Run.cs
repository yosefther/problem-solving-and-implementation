
namespace Stack
{
    internal class Run
    {
        static void Main(string[] args)
        {
            // Test the stack implementation based on an array
            Console.WriteLine("Testing ArrayStack:");
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            Console.WriteLine("Is ArrayStack empty? " + arrayStack.Empty());
            arrayStack.Push(10);
            arrayStack.Push(20);
            arrayStack.Push(30);
            Console.WriteLine("Is ArrayStack empty? " + arrayStack.Empty());
            Console.WriteLine("Contents of ArrayStack:");
            arrayStack.Display();

            // Test the stack implementation based on a linked list
            Console.WriteLine("\nTesting LinkedListStack:");
            LinkedListBase<int> linkedListStack = new LinkedListBase<int>();
            linkedListStack.Push(39);
            linkedListStack.Push(21);
            linkedListStack.Push(23);
            linkedListStack.Pop();
            linkedListStack.Pop();
            Console.WriteLine("Contents of LinkedListStack:");
            linkedListStack.Print();
        }
    }
 
}

