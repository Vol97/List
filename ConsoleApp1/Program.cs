using System;
using List;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            DoubleLinkedList doubleLinkedList1 = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Console.WriteLine(doubleLinkedList.ToString());
            Console.WriteLine(doubleLinkedList.ToStringTest());
        }
    }
}
