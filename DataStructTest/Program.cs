using System.Threading.Channels;
using DataStructLib;

namespace DataStructTest;

class Program
{
    //Draft area. It's able to show a particular output of the methods
    static void Main(string[] args)
    {
        MyLinkedList list = new MyLinkedList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.AddFirst(5);
        list.Add(77);
        
        list.PrintLinkedList();

        Console.WriteLine(list.Contains(5));
        Console.WriteLine(list.Contains(2));
        Console.WriteLine(list.Contains(100));
        
        list.Insert(2, 100);
        
        Console.WriteLine(list.Count);
        
        list.PrintLinkedList();
        
        object[] array = list.ToArray();
        
        Console.WriteLine(string.Join(" ", array));
        
        Console.WriteLine(list.First);
        Console.WriteLine(list.Last);
        
        list.Clear();
        
        list.PrintLinkedList();
        
        Console.WriteLine(list.Count);
    }
}