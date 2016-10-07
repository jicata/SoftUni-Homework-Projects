using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_DoublyLinkedListBasedQueueTests
{
    using _05_DoublyLinkedListBasedStack;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEnqueueDequeue_ShouldReturn_CorrectCount()
        {
            //Arrange
            int number = 1;
            var queue = new DoublyLinkedQueue<int>();
            //Act
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue(number);
            //Assert
            Assert.AreEqual(1, queue.Count);
            int expected = queue.Dequeue();
            Assert.AreEqual(expected, number);
            Assert.AreEqual(0, queue.Count);

        }


        [TestMethod]
        public void TestEnqueueDequeue_1000Times_ShouldReturn_CorrectCount()
        {
            var queue = new DoublyLinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);
            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i);
                Assert.AreEqual(i + 1, queue.Count);
            }
            int count = queue.Count;
            for (int i = 0; i < 1000; i++)
            {
                int element = queue.Dequeue();
                count--;
                Assert.AreEqual(i, element);
                Assert.AreEqual(count, queue.Count);
               
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeue_With_Emptyqueue_ShouldThrow()
        {
            var queue = new DoublyLinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void TestEnqueueDequeue_With_SpecificallySizedqueue_ShouldWorkCorrectly()
        {
            int firstElement = 420;
            int secondElement = 69;
            var queue = new DoublyLinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue(firstElement);
            Assert.AreEqual(1, queue.Count);
            queue.Enqueue(secondElement);
            Assert.AreEqual(2, queue.Count);
            var element = queue.Dequeue();
            Assert.AreEqual(firstElement, element);
            Assert.AreEqual(1, queue.Count);
            var anotherElement = queue.Dequeue();
            Assert.AreEqual(secondElement, anotherElement);
            Assert.AreEqual(0, queue.Count);

        }

        [TestMethod]
        public void TestToArray_ShouldReturn_ElementsOrderOfQueuing()
        {
            int[] arrayChe = new[]
            {
                1337, 666,  420, 69
            };
            var queue = new DoublyLinkedQueue<int>();
            queue.Enqueue(1337);
            queue.Enqueue(666);
            queue.Enqueue(420);
            queue.Enqueue(69);

            var arrayBe = queue.ToArray();

            CollectionAssert.AreEqual(arrayChe, arrayBe);
        }

        [TestMethod]
        public void TestToArray_WithEmptyQueue_ShouldReturn_EmptyArray()
        {
            DateTime[] dates = new DateTime[0];
            var queue = new DoublyLinkedQueue<DateTime>();
            var queueToArray = queue.ToArray();

            CollectionAssert.AreEqual(dates, queueToArray);
        }
    }
}
