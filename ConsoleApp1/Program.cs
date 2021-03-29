using System;
using List;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5 });
            DoubleLinkedList doubleLinkedList1 = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            DoubleLinkedNode doubleLinkedNode0 = doubleLinkedList.GetNodeByIndex(0);
            DoubleLinkedNode doubleLinkedNode1 = doubleLinkedList.GetNodeByIndex(1);
            DoubleLinkedNode doubleLinkedNode2 = doubleLinkedList.GetNodeByIndex(2);
            DoubleLinkedNode doubleLinkedNode3 = doubleLinkedList.GetNodeByIndex(3);
            DoubleLinkedNode doubleLinkedNode4 = doubleLinkedList.GetNodeByIndex(4);

            Console.WriteLine(doubleLinkedNode0.ToString());
            Console.WriteLine(doubleLinkedNode1.ToString());
            Console.WriteLine(doubleLinkedNode2.ToString());
            Console.WriteLine(doubleLinkedNode3.ToString());
            Console.WriteLine(doubleLinkedNode4.ToString());
        }
    }
}
