using System.Threading.Channels;
using DataStructLib;

namespace DataStructTest;

class Program
{
    //Draft area. It's able to show a particular output of the methods
    static void Main(string[] args)
    {
        BinaryTree myTree = new BinaryTree();
        
        myTree.Add(10);
        myTree.Add(20);
        myTree.Add(5);
        myTree.Add(1);
        myTree.Add(111);

        Console.WriteLine(myTree.Count);

        Console.WriteLine(myTree.Contains(20));
        Console.WriteLine(myTree.Contains(50));
        
        int[] intArray = myTree.ToArray();
        Console.WriteLine(intArray.Length);
        Console.WriteLine(intArray[0]);
        
        myTree.Clear();

        Console.WriteLine("---After Clear----");
        
        Console.WriteLine(myTree.Contains(20));
        Console.WriteLine(myTree.Contains(50));
        Console.WriteLine(myTree.Count);
    }
}