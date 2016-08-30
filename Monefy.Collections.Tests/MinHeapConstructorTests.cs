using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Monefy.Collections.Tests
{
    public class MinHeapConstructorTests
    {
        private int _expectedCapacity = 100;

        [Fact]
        public void MinHeap_ShouldBeCreated_WhenDefaultConstructorIsUsedAndGenericTypeParameterImplementsIComparable()
        {
            //act
            var sut = new MinHeap<int>();

            //assert
            Assert.Equal(0, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldThrowInvalidOperationException_WhenDefaultConstructorIsUsedAndGenericTypeParameterDoeNotImplementsIComparable()
        {
            //act
            var exception = Assert.Throws<InvalidOperationException>(() => new MinHeap<ClassNotImplementingIComparable>());

            //assert
            Assert.Equal("IComparable should be implemented.", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldBeCreated_WhenConstructorWithCapacityIsUsedAndGenericTypeParameterImplementsIComparable()
        {
            //act
            var sut = new MinHeap<int>(_expectedCapacity);

            //assert
            Assert.Equal(_expectedCapacity, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentOutOfRangeException_WhenCapacityIsNegativeNumber()
        {
            //act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MinHeap<int>(-1));

            //assert
            Assert.Equal("Non-negative number required.\r\nParameter name: capacity\r\nActual value was -1.", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowInvalidOperationException_WhenConstructorWithCapacityIsUsedAndGenericTypeParameterDoeNotImplementsIComparable()
        {
            //act
            var exception = Assert.Throws<InvalidOperationException>(() => new MinHeap<ClassNotImplementingIComparable>(_expectedCapacity));

            //assert
            Assert.Equal("IComparable should be implemented.", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldBeCreated_WhenConstructorWithCapacityAndIComparerIsUsed()
        {
            //arrange
            IComparer<int> expectedComparer = Comparer<int>.Default;

            //act
            var sut = new MinHeap<int>(_expectedCapacity, expectedComparer);

            //assert
            Assert.Equal(_expectedCapacity, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentOutOfRangeException_WhenConstructorWithCapacityAndIComparerIsUsedAndCapacityIsNegativeNumber()
        {
            //arrange
            IComparer<int> expectedComparer = Comparer<int>.Default;

            //act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MinHeap<int>(-1, expectedComparer));

            //assert
            Assert.Equal("Non-negative number required.\r\nParameter name: capacity\r\nActual value was -1.", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowInvalidOperationException_WhenConstructorWithCapacityAndIComparerIsUsedAndIComparerIsNull()
        {
            //arrange
            IComparer <ClassNotImplementingIComparable> expectedComparer = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(_expectedCapacity, expectedComparer));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: comparer", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldBeCreatedWithElementsOfCollecction_WhenConstructorWithEnumerableIsUsedAndGenericTypeParameterImplementsIComparable()
        {
            //arrange
            int expectedSize = 10;
            ICollection<int> expectedEnumerable = Enumerable.Range(0, expectedSize).ToArray();

            //act
            var sut = new MinHeap<int>(expectedEnumerable);

            //assert
            Assert.Equal(expectedEnumerable.Count, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldBeCreatedWithElementsOfIEnumerable_WhenConstructorWithEnumerableIsUsedAndGenericTypeParameterImplementsIComparable()
        {
            //arrange
            int expectedSize = 10;
            IEnumerable<int> expectedEnumerable = Enumerable.Range(0, expectedSize);

            //act
            var sut = new MinHeap<int>(expectedEnumerable);

            //assert
            Assert.Equal(expectedSize, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentNullException_WhenConstructorWithEnumerableIsUsedAndEnumerableIsNull()
        {
            //arrange
            IEnumerable<ClassNotImplementingIComparable> expectedNullEnumerable = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedNullEnumerable));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: collection", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentNullException_WhenConstructorWithEnumerableIsUsedAndCollectionIsNull()
        {
            //arrange
            ICollection<ClassNotImplementingIComparable> expectedNullCollection = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedNullCollection));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: collection", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowInvalidOperationException_WhenConstructorWithEnumerableAndGenericTypeParameterDoeNotImplementsIComparable()
        {
            //arrange
            ICollection<ClassNotImplementingIComparable> expectedCollection = new ClassNotImplementingIComparable[] 
            {
                new ClassNotImplementingIComparable()
            };

            //act
            var exception = Assert.Throws<InvalidOperationException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedCollection));

            //assert
            Assert.Equal("IComparable should be implemented.", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldBeCreatedWithElementsOfCollecction_WhenConstructorWithCollectionAndIComaprerIsUsed()
        {
            //arrange
            int expectedSize = 10;
            ICollection<int> expectedEnumerable = Enumerable.Range(0, expectedSize).ToArray();
            IComparer<int> expectedComparer = Comparer<int>.Default;

            //act
            var sut = new MinHeap<int>(expectedEnumerable, expectedComparer);

            //assert
            Assert.Equal(expectedEnumerable.Count, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldBeCreatedWithElementsOfIEnumerable_WhenConstructorWithEnumerableAndIComaprerIsUsed()
        {
            //arrange
            int expectedSize = 10;
            IEnumerable<int> expectedEnumerable = Enumerable.Range(0, expectedSize);
            IComparer<int> expectedComparer = Comparer<int>.Default;

            //act
            var sut = new MinHeap<int>(expectedEnumerable, expectedComparer);

            //assert
            Assert.Equal(expectedSize, sut.Capacity);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentNullException_WhenConstructorWithEnumerableAndIComaprerIsUsedAndCollectionIsNull()
        {
            //arrange
            IEnumerable<ClassNotImplementingIComparable> expectedNullEnumerable = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedNullEnumerable));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: collection", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentNullException_WhenConstructorWithICollectionAndIComaprerIsUsedAndCollectionIsNull()
        {
            //arrange
            ICollection<ClassNotImplementingIComparable> expectedNullCollection = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedNullCollection));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: collection", exception.Message);
        }

        [Fact]
        public void MinHeap_ShouldThrowArgumentNullException_WhenConstructorWithEnumerableAndIComaprerIsUsedAndIComparerIsNull()
        {
            //arrange
            ICollection<ClassNotImplementingIComparable> expectedCollection = new ClassNotImplementingIComparable[]
            {
                new ClassNotImplementingIComparable()
            };
            IComparer<ClassNotImplementingIComparable> expectedComparer = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => new MinHeap<ClassNotImplementingIComparable>(expectedCollection, expectedComparer));

            //assert
            Assert.Equal("Value cannot be null.\r\nParameter name: comparer", exception.Message);
        }
    }

    internal class ClassNotImplementingIComparable
    {
        public int Id { get; set; }
    }

    internal class ClassNotImplementingIComparableComparer : IComparer<ClassNotImplementingIComparable>
    {
        public int Compare(ClassNotImplementingIComparable x, ClassNotImplementingIComparable y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
