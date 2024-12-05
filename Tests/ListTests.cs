using DataStructLib;
using NUnit.Framework;
using DataStructInterfaces;

namespace Tests;

public class ListTests
{
    [Test]
    public void MyAddMethodTest()
    {
        //arrange
        MyList myList = new MyList();
        
        //act
        myList.Add(5);
        myList.Add(10);
        myList
        
        //assert
        Assert.That(myList.Contains(5), Is.True);
        Assert.That(myList.Contains(10), Is.True);
        Assert.That(myList.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void MyInsertMethodTest()
    {
        //arrange
        MyList myList = new MyList();
        myList.Add(2);
        myList.Add(4);
        
        //act
        myList.MyInsert(1, 44);
        myList.MyInsert(2, 77);

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
        MyList myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        var index1 = myList.MyIndexOf(5);
        var index2 = myList.MyIndexOf(10);
        
        //assert
        Assert.That(index1, Is.EqualTo(0));
        Assert.That(index2, Is.EqualTo(1));
    }
    
    [Test]
    public void MyContainsMethodTest()
    {
        //arrange
        MyList myList = new MyList();
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
        MyList myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.MyReverse();
        
        //assert
        Assert.That(myList[0], Is.EqualTo(10));
        Assert.That(myList[1], Is.EqualTo(5));
    }
    
    [Test]
    public void MyRemoveMethodTest()
    {
        //arrange
        MyList myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.MyRemove(10);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(5));
        Assert.That(myList[1], Is.EqualTo(null));
    }
    
    [Test]
    public void MyRemoveAtMethodTest()
    {
        //arrange
        MyList myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.MyRemoveAt(0);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(10));
        Assert.That(myList[1], Is.EqualTo(null));
    }
    
    [Test]
    public void MyClearMethodTest()
    {
        //arrange
        MyList myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        myList.MyClear();

        Console.WriteLine(myList.Count);
        
        //assert
        Assert.That(myList[0], Is.EqualTo(null));
        Assert.That(myList[1], Is.EqualTo(null));
    }
    
    [Test]
    public void MyToArrayMethodTest()
    {
        //arrange
        var myList = new MyList();
        myList.Add(5);
        myList.Add(10);
        
        //act
        Array array = myList.MyToArray();
        
        //assert
        Assert.That(array.Length, Is.EqualTo(2));
    }
}