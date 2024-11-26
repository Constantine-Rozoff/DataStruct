using DataStructLib;
using NUnit.Framework;

namespace DataStructTest;

public class Tests
{
    int desiredNumber = 3;
        
    object[] strings = { "1", "2", "3" };
    string desiredString = "1";
    
    [Test]
    public void MyAddMethodTest()
    {
        //arrange
        object[] numbers = { 1, 2, 3 };
        
        //act
        object[]?resultArray = MyList.MyAdd(numbers, 5);
        
        resultArray = MyList.MyAdd(resultArray, 10);
        
        //assert
        Assert.That(resultArray.Contains(5), Is.True);
        Assert.That(resultArray.Contains(10), Is.True);
    }
}