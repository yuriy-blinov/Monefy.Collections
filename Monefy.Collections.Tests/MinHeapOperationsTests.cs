using System;
using Xunit;

namespace Monefy.Collections.Tests
{
    public class MinHeapOperationsTests
    {
        [Fact]
        public void Add_ShouldAddElementToTheRoot_WhenHeapIsEmpty()
        {
            //arrange
            int expectedElement = 10;
            var sut = new MinHeap<int>();

            //act
            sut.Add(expectedElement);

            //arrange
            Assert.Equal(expectedElement, sut.PeekMin());
            Assert.Equal(4, sut.Capacity);
        }

        [Fact]
        public void Add_ShouldAddElementToTheRoot_WhenHeapHasAlreadyOneElement()
        {
            //arrange
            var sut = new MinHeap<int>();

            //act
            sut.Add(11);
            sut.Add(5);

            //arrange
            Assert.Equal(5, sut.PeekMin());
            Assert.Equal(4, sut.Capacity);
        }

        [Fact]
        public void Add_ShouldThrowArgumentNullException_WhenNullIsAdded()
        {
            //arrange
            string expectedElement = null;
            var sut = new MinHeap<string>();

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => sut.Add(expectedElement));

            //arrange
            Assert.Equal("Value cannot be null.\r\nParameter name: item", exception.Message);
        }

        [Fact]
        public void PeekMin_ShouldThrowInvalidOperationException_WhenHeapIsEmpty()
        {
            //arrange
            var sut = new MinHeap<string>();

            //act
            var exception = Assert.Throws<InvalidOperationException>(() => sut.PeekMin());

            //arrange
            Assert.Equal("Heap is empty.", exception.Message);
        }
    }
}
