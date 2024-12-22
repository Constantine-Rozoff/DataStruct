using System.Diagnostics;
using DataStructLib;
using NUnit.Framework;

namespace Tests;

public class BinaryTreeTests
{
    [Test]
    public void AddMethodTest()
    {
        //arrange
        BinaryTree<int> tree = new BinaryTree<int>();
        
        tree.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        //act
        tree.Add(5);
        tree.Add(10);
        
        //assert
        Assert.That(tree.Contains(5), Is.True);
        Assert.That(tree.Contains(10), Is.True);
        Assert.That(tree.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void ToArrayMethodTest()
    {
        //arrange
        BinaryTree<int> tree = new BinaryTree<int>();
        
        tree.Add(5);
        tree.Add(10);
        tree.Add(20);
        
        //act
         int[] intArray = tree.ToArray();

        //assert
        Assert.That(intArray.Length, Is.EqualTo(3));
        Assert.That(intArray[0], Is.EqualTo(5));
        Assert.That(intArray[1], Is.EqualTo(10));
        Assert.That(intArray[2], Is.EqualTo(20));
    }
    
    [Test]
    public void ClearMethodTest()
    {
        //arrange
        BinaryTree<int> tree = new BinaryTree<int>();
        
        tree.ListChanged += (sender, args) =>
        {
            Debug.WriteLine($"Method: {args.ChangeType}, Item: {args.Item}, Index: {args.Index}");
        };
        
        tree.Add(5);
        tree.Add(10);
        tree.Add(20);
        
        //act
        tree.Clear();

        //assert
        Assert.That(tree.Count, Is.EqualTo(0));
    }
}