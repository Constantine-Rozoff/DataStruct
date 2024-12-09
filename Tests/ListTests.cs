using DataStructLib;
using NUnit.Framework;

namespace Tests;

public class ListTests
{
    [Test]
    public void MyAddMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        
        //act
        myList.Add(5);
        myList.Add(10);
        
        //assert
        Assert.That(myList.Contains(5), Is.True);
        Assert.That(myList.Contains(10), Is.True);
        Assert.That(myList.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void MyInsertMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(2);
        myList.Add(4);
        
        //act
        myList.Insert(1, 44);
        myList.Insert(2, 77);

        for (int i = 0; i < myList.Count - 1; i++)
        {
            Console.WriteLine(myList[i]);
        }
        
        //assert
        Assert.That(myList.Contains(44), Is.True);
        Assert.That(myList.Contains(77), Is.True);
        Assert.That(myList.Count, Is.EqualTo(4));
    }
    
    [Test]
    public void MyIndexOfMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        var index1 = myList.IndexOf(5);
        var index2 = myList.IndexOf(10);
        
        //assert
        Assert.That(index1, Is.EqualTo(0));
        Assert.That(index2, Is.EqualTo(1));
    }
    
    [Test]
    public void MyContainsMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act and assert
        Assert.That(myList.Contains(5), Is.True);
        Assert.That(myList.Contains(10), Is.True);
        Assert.That(myList.Contains(17), Is.False);
    }
    
    [Test]
    public void MyReverseMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.Reverse();
        
        //assert
        Assert.That(myList[0], Is.EqualTo(10));
        Assert.That(myList[1], Is.EqualTo(5));
    }
    
    [Test]
    public void MyRemoveMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.Remove(10);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(5));
        Assert.That(myList[1], Is.EqualTo(0));
    }
    
    [Test]
    public void MyRemoveAtMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.RemoveAt(0);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(10));
        Assert.That(myList[1], Is.EqualTo(0));
    }
    
    [Test]
    public void MyClearMethodTest()
    {
        //arrange
        MyList<int> myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.Clear();

        Console.WriteLine(myList.Count);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(0));
        Assert.That(myList[1], Is.EqualTo(0));
    }
    
    [Test]
    public void MyToArrayMethodTest()
    {
        //arrange
        var myList = new MyList<int>();
        myList.Add(5);
        myList.Add(10);
        
        //act
        Array array = myList.ToArray();
        
        //assert
        Assert.That(array.Length, Is.EqualTo(2));
    }
}