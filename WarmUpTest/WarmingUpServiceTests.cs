using WarmUp;
using Xunit.Abstractions;

namespace WarmUpTest;

public class WarmingUpServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public WarmingUpServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestIsPowerOfTwo()
    {
        var bookId = -1;
        var isPowerOfTwo = WarmingUpService.IsPowerOfTwo(bookId);
        _testOutputHelper.WriteLine($"{bookId} is power of two? {isPowerOfTwo.ToString()}");
    }
    
    [Fact]
    public void TestStringReverser()
    {
        var sampleString = "Hello";
        var reversedString = WarmingUpService.ReverseString(sampleString);
        _testOutputHelper.WriteLine($"{sampleString} reversed is {reversedString}");
    }

    [Fact]
    public void TestStringReplicator()
    {
        var sampleString = "Hello";
        var numberOfReplicas = 2;
        var replicatedString = WarmingUpService.ReplicateString(sampleString, numberOfReplicas);
        _testOutputHelper.WriteLine($"{sampleString} replicated {numberOfReplicas} times is {replicatedString}");
    }

    [Fact]
    public void OddNumbersWriter()
    {
        for (int i = 0; i < 101; i++)
        {
            if (i % 2 != 0)
            {
                _testOutputHelper.WriteLine($"{i} is odd number");
            }
        }
    }
}