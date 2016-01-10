using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(100, 100, 100, 1000)]
    public void TestMethod2(int maxLength, int maxValue, int maxOperationCount, int repeatCount)
    {
        Repeat(repeatCount, () =>
        {
            var nums = GenerateIntegerArray(maxLength, maxValue);
            var numArray = new NumArray(nums);
            var numsCopy = nums.ToArray();
            var operationCount = nums.Any() ? Random.Next(maxOperationCount) + 1 : 0;
            //System.Console.WriteLine(JsonConvert.SerializeObject(numsCopy));
            for (var i = 0; i < operationCount; ++i)
            {
                switch(Random.Next(2))
                {
                    case 0:
                        var index = Random.Next(nums.Length);
                        var newValue = Random.Next(maxValue + 1);
                        numArray.Update(index, newValue);
                        numsCopy[index] = newValue;
                        //System.Console.WriteLine(JsonConvert.SerializeObject(numsCopy));
                        break;
                    default:
                        var indexI = Random.Next(nums.Length);
                        var indexJ = Random.Next(nums.Length);
                        if (indexI > indexJ)
                        {
                            var t = indexI;
                            indexI = indexJ;
                            indexJ = t;
                        }
                        Assert.AreEqual(Sum(numsCopy, indexI, indexJ), numArray.SumRange(indexI, indexJ),
                        $"i = {indexI} j = {indexJ} nums = {JsonConvert.SerializeObject(numsCopy)}");
                        break;
                }
            }
        });
    }

    private int Sum(int[] nums, int i, int j)
    {
        return nums.Skip(i).Take(j - i + 1).Sum();
    }
}