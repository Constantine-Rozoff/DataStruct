using System.Diagnostics;
using DataStructLib;
using NUnit.Framework;

namespace Tests;

public class DoubleLinkedListTests
{
    [Test]
    public void AddFirstMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        //act
        doubleList.AddFirst(5);
        doubleList.AddFirst(10);
        
        doubleList.PrintLinkedList();
        
        //assert
        Assert.That(doubleList.Contains(5), Is.True);
        Assert.That(doubleList.Contains(10), Is.True);
        Assert.That(doubleList.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void AddMethodAndFirstAndLastPropertyTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        doubleList.Add(5);
        doubleList.Add(10);
        
        //act
        doubleList.AddFirst(88);
        
        //assert
        Assert.That(doubleList.Contains(88), Is.True);
        Assert.That(doubleList.First, Is.EqualTo(88));
        Assert.That(doubleList.Last, Is.EqualTo(10));
        Assert.That(doubleList.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void ContainsMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        doubleList.Add(5);
        
        //act
        //assert
        Assert.That(doubleList.Contains(5), Is.True);
        Assert.That(doubleList.Contains(88), Is.False);
        
    }
    
    [Test]
    public void RemoveMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        doubleList.Add(5);
        doubleList.Add(10);
        
        doubleList.PrintLinkedList();
        
        //act
        doubleList.Remove(5);
        
        doubleList.PrintLinkedList();
        
        //assert
        Assert.That(doubleList.Contains(5), Is.False);
        Assert.That(doubleList.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void RemoveFirstMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        doubleList.Add(5);
        doubleList.Add(10);
        doubleList.Add(55);
        
        //act
        doubleList.RemoveFirst();
        doubleList.RemoveFirst();
        
        //assert
        Assert.That(doubleList.Contains(5), Is.False);
        Assert.That(doubleList.Contains(10), Is.False);
        Assert.That(doubleList.Contains(55), Is.True);
        Assert.That(doubleList.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void RemoveLastMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        doubleList.Add(5);
        doubleList.Add(10);
        doubleList.Add(55);
        
        doubleList.PrintLinkedList();
        
        //act
        doubleList.RemoveLast();
        
        doubleList.PrintLinkedList();
        
        //assert
        Assert.That(doubleList.Contains(5), Is.True);
        Assert.That(doubleList.Contains(10), Is.True);
        Assert.That(doubleList.Contains(55), Is.False);
        Assert.That(doubleList.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void ToArrayMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        doubleList.Add(5);
        doubleList.Add(10);
        doubleList.Add(55);
        
        //act
        Array doubleArray = doubleList.ToArray();
        
        //assert
        Assert.That(doubleArray.Length, Is.EqualTo(3));
    }
    
    [Test]
    public void ClearMethodTest()
    {
        //arrange
        DoubleLinkedList<int> doubleList = new DoubleLinkedList<int>();
        
        doubleList.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        doubleList.Add(5);
        doubleList.Add(10);
        doubleList.Add(55);
        
        //act
        doubleList.Clear();
        
        //assert
        Assert.That(doubleList.Contains(5), Is.False);
        Assert.That(doubleList.Contains(10), Is.False);
        Assert.That(doubleList.Contains(55), Is.False);
        Assert.That(doubleList.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void FilterIteratorTest()
    {
        //arrange
        var doubleList = new DoubleLinkedList<int>{
            1,
            2,
            3,
            5,
            6,
            14,
            7,
            4,
            8,
            10,
            9,
            11,
            13,
            12
        };
        
        //act
        var query = doubleList.Filter(item => item % 2 == 0);

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }
        
        //assert
        Assert.That(query.All(item => item % 2 == 0), Is.True);
    }
    
    [Test]
    public void SkipWhileIteratorTest()
    {
        //arrange
        var doubleList = new DoubleLinkedList<int>{
            1,
            2,
            3,
            5,
            6,
            14,
            7,
            4,
            8,
            10,
            9,
            11,
            13,
            12
        };
        
        //act
        var query = doubleList.MySkipWhile(item => item <= 5);

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }
        
        //assert
        Assert.That(query.All(item => item > 5), Is.True);
    }
}