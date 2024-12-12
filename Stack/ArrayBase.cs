using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;

namespace Stack
{
    internal class ArrayBase
    {
        static void Main(string[] args)
        {
            ArrayStack<int> test = new ArrayStack<int>();
            Console.WriteLine(test.Empty());
            test.Push(10);
            test.Push(20);
            test.Push(30);
            Console.WriteLine(test.Empty());
            test.Display();
        }
    }
    class ArrayStack<T>
    {
        private T[] Items;
        private int Top = 0;
        public ArrayStack (){
            Items = new T[10];
            Top = -1; 
}

        public void Push(T data)
        {

                Items[++Top] = data;
        }
        public bool Empty()
        {
            return Top == -1;
        }
        public T Pop()
        {
            return Items[Top--];
        }
        public  void Display()
        {
            while (Top>-1)
            {
                Console.WriteLine(Items[Top--]);
            }
        }
    }
}

