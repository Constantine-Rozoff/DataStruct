using DataStructLib;
using NUnit.Framework;

namespace Tests;

public class LinkedListTests
{
    [Test]
    public void AddMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        
        //act
        linkedList.Add(5);
        linkedList.Add(10);
        
        //assert
        Assert.That(linkedList.Contains(5), Is.True);
        Assert.That(linkedList.Contains(10), Is.True);
        Assert.That(linkedList.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void AddFirstAndFirstPropertyMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        linkedList.Add(5);
        linkedList.Add(10);
        
        //act
        linkedList.AddFirst(88);
        
        //assert
        Assert.That(linkedList.Contains(88), Is.True);
        Assert.That(linkedList.First, Is.EqualTo(88));
    }
    
    [Test]
    public void CountPropertyTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        
        //act
        linkedList.Add(5);
        linkedList.Add(10);
        linkedList.Add(15);
        
        //assert
        Assert.That(linkedList.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void LastPropertyTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        
        //act
        linkedList.Add(5);
        linkedList.Add(10);
        
        //assert
        Assert.That(linkedList.Last, Is.EqualTo(10));
    }
    
    [Test]
    public void InsertMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        linkedList.Add(5);
        linkedList.Add(10);
        
        //act
        
        linkedList.Insert(1, 25);
        
        linkedList.PrintLinkedList();
        
        //assert
        Assert.That(linkedList.First, Is.EqualTo(5));
        Assert.That(linkedList.Last, Is.EqualTo(10));
        Assert.That(linkedList.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void ContainsMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        
        //act
        linkedList.Add(5);
        linkedList.Add(10);
        
        //assert
        Assert.That(linkedList.Contains(5), Is.True);
        Assert.That(linkedList.Contains(10), Is.True);
    }
    
    
    [Test]
    public void ClearMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        linkedList.Add(5);
        linkedList.Add(10);

        //act
        linkedList.Clear();
        
        //assert
        Assert.That(linkedList.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void ToArrayMethodTest()
    {
        //arrange
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        linkedList.Add(5);
        linkedList.Add(10);

        //act
        Array array = linkedList.ToArray();
        
        //assert
        Assert.That(array.Length, Is.EqualTo(2));
    }
}