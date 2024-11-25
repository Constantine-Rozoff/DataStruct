using DataStructLib;

namespace DataStructTest;

class Program
{
    static void Main(string[] args)
    {
        object[] numbers = { 1, 2, 3 };
        int desiredNumber = 3;
        
        object[] strings = { "1", "2", "3" };
        string desiredString = "1";
        
        
        Console.WriteLine(MyList.MyIndexOf(numbers, desiredNumber));
        Console.WriteLine(MyList.MyIndexOf(strings, desiredString));
        
        Console.WriteLine(MyList.MyContains(numbers, desiredNumber));
        Console.WriteLine(MyList.MyContains(strings, desiredString));
        
        object[]?resultArray = MyList.MyAdd(numbers, 5);
        Console.WriteLine(resultArray?[3]);
        
        object[]?resultArray2 = MyList.MyAdd(numbers, 10);
        Console.WriteLine(resultArray2?[3]);
        
        object[]? insertArray = MyList.MyInsert(numbers, 1, 99);
        
        if (insertArray != null)
            foreach (var item in insertArray)
            {
                Console.WriteLine(item);
            }
        
        Console.WriteLine("---------------" + "MyReverse" + "---------------");
        
        object[] reversedArray = MyList.MyReverse(numbers);
        
        if (insertArray != null)
            foreach (var item in reversedArray)
            {
                Console.WriteLine(item);
            }
        
        Console.WriteLine("---------------" + "MyRemoveAt" + "---------------");
        
        MyList.MyRemoveAt(numbers, 2);
        
        if (insertArray != null)
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        
        Console.WriteLine("---------------" + "MyRemove" + "---------------");
        
        bool isRemoved = MyList.MyRemove(numbers, 3);

        Console.WriteLine(isRemoved);
        
        if (numbers != null)
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
    }
}