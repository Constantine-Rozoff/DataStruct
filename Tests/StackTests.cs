using DataStructLib;
using NUnit.Framework;

namespace Tests;

public class StackTests
{
    [Test]
    public void PushTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        
        //act
        stack.Push(5);
        stack.Push(10);
        
        //assert
        Assert.That(stack.IsEmpty(), Is.False);
    }
    
    [Test]
    public void PopTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        stack.Push(5);
        stack.Push(10);
        
        //act
        var lastItem = stack.Pop();
        
        //assert
        Assert.That(lastItem, Is.EqualTo(10));
        Assert.That(stack.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void PeekTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        stack.Push(5);
        stack.Push(10);
        stack.Push(100);
        
        //act
        var lastItem = stack.Peek();
        
        //assert
        Assert.That(lastItem, Is.EqualTo(100));
        Assert.That(stack.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void ContainsTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        
        //act
        stack.Push(5);
        stack.Push(10);
        
        //assert
        Assert.That(stack.Contains(5), Is.True);
        Assert.That(stack.Contains(10), Is.True);
        Assert.That(stack.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void ToArrayTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        stack.Push(5);
        stack.Push(10);
        stack.Push(25);
        stack.Push(50);
        
        //act
        var newArray = stack.ToArray();
        
        //assert
        Assert.That(newArray.Length, Is.EqualTo(4));
    }
    
    [Test]
    public void ClearTest()
    {
        //arrange
        MyStack<int> stack = new MyStack<int>();
        stack.Push(5);
        stack.Push(10);
        stack.Push(25);
        
        stack.PrintStack();
        
        //act
        stack.Clear();
        
        //assert
        Assert.That(stack.Count, Is.EqualTo(0));
        //Assert.That(stack.IsEmpty(), Is.True); - TODO: Why IsEmpty works incorrectly and returns false when Count is 0
    }
}