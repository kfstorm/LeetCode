using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(100)]
    public void TestMethod(int operationCount)
    {
        var random = new Random();
        var stack = new Stack<int>();
        var heap = new SortedList<int, int>();
        var minStack = new MinStack();
        for (var i = 0; i < operationCount; ++i)
        {
            var operation = stack.Count == 0 ? 0 : random.Next(4);
            var x = random.Next(int.MaxValue);
            switch (operation)
            {
                case 0: // Push
                    stack.Push(x);
                    heap.Add(x, x);
                    minStack.Push(x);
                    break;
                case 1: // Pop
                    heap.Remove(stack.Peek());
                    stack.Pop();
                    minStack.Pop();
                    break;
                case 2: // Top
                    Assert.AreEqual(stack.Peek(), minStack.Top());
                    break;
                case 3: // GetMin
                    Assert.AreEqual(heap.First().Key, minStack.GetMin());
                    break;
            }
        }
    }
}
