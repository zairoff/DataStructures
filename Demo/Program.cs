using System;
using Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine("Hello World!");
        }
    }
}
