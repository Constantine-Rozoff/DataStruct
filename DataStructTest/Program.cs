using DataStructLib;

namespace DataStructTest;

class Program
{
    //Draft area. It's able to show a particular output of the methods
    static void Main(string[] args)
    {
        Console.WriteLine("-----Initial Count-----");
        
        MyList list = new MyList();
        var listCount = list.Count;
        Console.WriteLine(listCount);
        
        Console.WriteLine("-----My Add-----");
        list.MyAdd(50);

        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        
        listCount = list.Count;
        Console.WriteLine(listCount);


        list.MyAdd(1);
        list.MyAdd(2);
        list.MyAdd(3);
        
        Console.WriteLine("----");

        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        
        Console.WriteLine("-----My Insert-----");
        
        list.MyInsert(1, 44);

        list.MyInsert(5, 77);
        
        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        Console.WriteLine("-----My Index Of-------");

        Console.WriteLine(list.MyIndexOf(77));
        Console.WriteLine(list.MyIndexOf(111));
        
        Console.WriteLine("-----My Contains-------");
        
        Console.WriteLine(list.MyContains(-1));
        Console.WriteLine(list.MyContains(5));
        Console.WriteLine(list.MyContains(77));

        Console.WriteLine("---Reverse----");
        
        list.MyReverse();
        
        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        
        Console.WriteLine("---Remove----");

        list?.MyRemove(44);
        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        
        Console.WriteLine("---RemoveAT----");

        list?.MyRemoveAt(0);
        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        
        Console.WriteLine("---ToArray----");

        var resultedArray = list?.MyToArray();
        if (resultedArray == null) return;
        {
            foreach (var t in resultedArray)
            {
                Console.WriteLine(t);
            }
        }
        
        Console.WriteLine("---Clear----");

        list?.MyClear();
        if (list != null)
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i] + "item");
            }
    }
}