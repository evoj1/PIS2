using PIS2.Parsers;
namespace UnitTests;

[TestClass]
public class NumberCounterTests
{
    [TestMethod]
    public void CountNumbers_SimpleString()
    {
        var parser = new LessonParser();
        string input = "10 020 0003";
        int goodResult = 3;
        int realResult = parser.CountNumbers(input);

        Assert.AreEqual(goodResult, realResult);
    }
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void CountNumbers_StringIsNull()
    {
        var parser = new LessonParser();
        string input = "";

        parser.CountNumbers(input);
    }
    [TestMethod]
    public void CountNumbers_FirstNull()
    {
        var parser = new LessonParser();
        string input = "0 1 2 3 4";
        int goodResult = 4;
        int realResult = parser.CountNumbers(input);

        Assert.AreEqual(goodResult, realResult);
    }
    [TestMethod]
    public void CountNumbers_TrimStart0()
    {
        var parser = new LessonParser();
        string input = "0001 1 2 3 4";
        int goodResult = 5;
        int realResult = parser.CountNumbers(input);

        Assert.AreEqual(goodResult, realResult);
    }
    [TestMethod]
    public void CountNumbers_AllZeros_ReturnsZero()
    {
        var parser = new LessonParser();
        string input = "0 00 000";
        int goodResult = 0;
        int realResult = parser.CountNumbers(input);

        Assert.AreEqual(goodResult, realResult);
    }
}
