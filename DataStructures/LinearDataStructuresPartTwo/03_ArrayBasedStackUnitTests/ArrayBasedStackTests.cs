using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_ArrayBasedStackUnitTests
{
    using _03_ArrayBasedStack;

    [TestClass]
    public class ArrayBasedStackTests
    {
        
        [TestMethod]
        public void TestPopPush_ShouldReturn_CorrectCount()
        {
            //Arrange
            int number = 1;
            var stack = new ArrayStack<int>();
            //Act
            Assert.AreEqual(0, stack.Count);
            stack.Push(number);
            //Assert
            Assert.AreEqual(1, stack.Count);
            int expected = stack.Pop();
            Assert.AreEqual(expected, number);
            Assert.AreEqual(0, stack.Count);

        }

        [TestMethod]
        public void TestPopPush_1000Times_ShouldReturn_CorrectCount()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);
            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i+1, stack.Count);
            }
            for (int i = stack.Count-1; i >= 0; i--)
            {
                int element = stack.Pop();
                Assert.AreEqual(i, element);
                Assert.AreEqual(i, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_With_EmptyStack_ShouldThrow()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestPopPush_With_SpecificallySizedStack_ShouldWorkCorrectly()
        {
            int firstElement = 420;
            int secondElement = 69;
            var stack = new ArrayStack<int>(1);
            Assert.AreEqual(0,stack.Count);
            stack.Push(firstElement);
            Assert.AreEqual(1, stack.Count);
            stack.Push(secondElement);
            Assert.AreEqual(2, stack.Count);
            var element = stack.Pop();
            Assert.AreEqual(secondElement, element);
            Assert.AreEqual(1, stack.Count);
            var anotherElement = stack.Pop();
            Assert.AreEqual(firstElement, anotherElement);
            Assert.AreEqual(0, stack.Count);

        }

        [TestMethod]
        public void TestToArray_ShouldReturn_ElementsInReversedOrderToPushing()
        {
            int[] arrayChe = new[]
            {
                69, 420, 666, 1337
            };   
            var stack = new ArrayStack<int>();
            stack.Push(1337);
            stack.Push(666);
            stack.Push(420);
            stack.Push(69);

            var arrayBe = stack.ToArray();

            CollectionAssert.AreEqual(arrayChe, arrayBe);
        }

        [TestMethod]
        public void TestToArray_WithEmptyStack_ShouldReturn_EmptyArray()
        {
            DateTime[] dates = new DateTime[0];
            var stack = new ArrayStack<DateTime>();
            var stackToArray = stack.ToArray();
            
            CollectionAssert.AreEqual(dates, stackToArray);
        }

    }
}
