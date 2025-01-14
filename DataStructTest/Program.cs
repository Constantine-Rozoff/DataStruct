using DataStructLib;
using DataStructInterfaces;

namespace DataStructTest;

class Program
{
    //Draft area. It's able to show a particular output of the methods
    static void Main(string[] args)
    {
        MyList<int> numbers = new MyList<int> {10, 20, 30, 40, 50};

        string str = "aaa;abb;ccc;dap";
        
        string str2 =  "aaa;xabbx;abb;ccc;dap";
        
        string str3 =  "aaa;xabbx;abb;ccc;dap;zh";
        
        string str4 =  "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh";
        
        //#1
        Console.WriteLine(string.Join(", ", numbers.Select(n => n.ToString())));
        
        //#2
        Console.WriteLine(string.Join(", ", numbers.Where(n => n % 3 == 0).Select(n => n.ToString())));
        
        //#3
        Console.WriteLine(string.Join(", ", Enumerable.Repeat("Linq", 10)));
        
        //#4
        Console.WriteLine(string.Join(", ", str.Split(";").Where(s => s.Contains("a")).Select(s => s.ToString())));
        
        //#5
        Console.WriteLine(string.Join(", ", str.Split(';').Select(s => s.Count(c => c == 'a'))));
        
        //#6
        Console.WriteLine(string.Join(", ", str2.Split(';').Select(s => s.Contains("abb"))));
        
        //#7
        Console.WriteLine(string.Join(", ", str2.Split(';').Where(s => s.Length > 3).Select(s => s.ToString())));
        
        //#8
        Console.WriteLine(string.Join(", ", str2.Split(';').Average(s => s.Length)));
        
        //#9
        Console.WriteLine(string.Join(", ", str3.Split(';').Where(s => s.Length <= 2).Reverse().Select(s => s.ToString())));
        
        //#10
        Console.WriteLine(string.Join(", ", str4.Split(';').Where(s => s.StartsWith("aa")).Where(s => s.Contains("bb")).Select(s => s.ToString())));
    }
}