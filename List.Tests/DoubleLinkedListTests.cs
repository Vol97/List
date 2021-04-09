using NUnit.Framework;
using System;

namespace List.Tests
{
    public class DoubleLinkedListTests
    {
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 10 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10 })]
        [TestCase(-10, new int[0], new int[] { -10 })]
        public void Add_WhenValuePassed_AddThisValueToTheEndOfTheList(int value, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { }, new int[] { -10 })]
        public void AddFirst_WhenValuePassed_AddThisValueOnTheFisrtPosition(int value, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 2, 3, 4, 5 })]
        [TestCase(0, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 0, 3, 4, 5 })]
        [TestCase(-10, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, -10, 4, 5 })]
        [TestCase(-10, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, -10, 5 })]
        [TestCase(-10, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(-10, 0, new int[] { 1 }, new int[] { -10, 1 })]
        public void AddAtIndex_WhenValuePassed_AddThisValueOnTheGivenIndex(int value, int index, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.AddAtIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(10, -1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(10, 5, new int[] { 1, 2, 3, 4, 5 })]
        public void AddAtIndex_WhenIndexIsLessThanZeroOrBiggerOrEqualsArrayLength_ThrowIndexOutOfRangeException(int value, int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.AddAtIndex(value, index); });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void Remove_WhenCalled_RemoveAValueFromTheEndOfTheList(int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void Remove_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.Remove(); });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirst_WhenCalled_RemoveAValueFromTheStartOfTheList(int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void RemoveFirst_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.RemoveFirst(); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 1 }, new int[] { })]
        public void RemoveAtIndex_WhenIndexPassed_RemoveAValueOnTheGivenIndex(int index, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveAtIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[0])]
        public void RemoveAtIndex_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.RemoveAtIndex(index); });
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveAtIndex_WhenIndexIsLessThanZeroOrEqualsToOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAtIndex(index); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        public void RemoveNElements_WhenNumberOfElementsPassed_RemoveNElemetsFromTheEndOfTheList(int numberOfElements, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveNElements(numberOfElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[0])]
        public void RemoveNElements_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int numberOfElements, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.RemoveNElements(numberOfElements); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        public void RemoveFirstNElements_WhenNumberOfElementsPassed_RemoveNElemetsFromTheStartOfTheList(int numberOfElements, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveFirstNElements(numberOfElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[0])]
        public void RemoveFirstNElements_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int numberOfElements, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.RemoveFirstNElements(numberOfElements); });
        }

        [TestCase(1, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 4, 5 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(5, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(7, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        public void RemoveNElementsAtIndex_WhenNumberOfElementsPassed_RemoveNElemetsAtIndex(int numberOfElements, int index, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveNElementsAtIndex(numberOfElements, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 0, new int[0])]
        public void RemoveNElementsAtIndex_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int numberOfElements, int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.RemoveNElementsAtIndex(numberOfElements, index); });
        }

        [TestCase(3, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, -1, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveNElementsAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int numberOfElements, int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveNElementsAtIndex(numberOfElements, index); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 1, 4, 5, 1 }, 0)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, -1)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(-1, new int[] { 1, 2, 3, 4, -1, 5 }, 4)]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5 }, -1)]
        public void GetFirstIndexByValue_WhenValuePassed_ReturnIndexOfTheElementWithGivenValue(int value, int[] doubleLinkedList, int expected)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            int actual = list.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1, 6, 5, 4, 3, 2, 1, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 1, 0, 0 })]
        [TestCase(new int[] { -1, 2, -3, 4, -5 }, new int[] { -5, 4, -3, 2, -1 })]
        [TestCase(new int[] { -1 }, new int[] { -1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_WhenCalled_ReverseArrayItsCalledOn(int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 9)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, 100)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 1)]
        [TestCase(new int[] { 10, 100, 10, 11 }, 100)]
        public void MaxValue_WhenCalled_ReturnTheMaxValueOfTheArray(int[] array, int expected)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(array);

            int actual = list.MaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 3)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, -100)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 1)]
        public void MinValue_WhenCalled_ReturnTheMinValueOfTheArray(int[] array, int expected)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(array);

            int actual = list.MinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 6)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, 3)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0)]
        [TestCase(new int[] { 10, 100, 10, 11 }, 1)]
        public void MaxValueIndex_WhenCalled_ReturnTheMaxValueIndex(int[] array, int expected)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(array);

            int actual = list.MaxValueIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MaxValueIndex_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.MaxValueIndex(); });
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 0)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0)]
        public void MinValueIndex_WhenCalled_ReturnTheMinValueIndex(int[] array, int expected)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(array);

            int actual = list.MinValueIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MinValueIndex_WhenUsedOnZeroLengthArray_ThrowInvalidOperationException(int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);

            Assert.Throws<InvalidOperationException>(() => { list.MinValueIndex(); });
        }

        [TestCase(true, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 3, 3, 4, 6, 7, 7, 8, 9 })]
        [TestCase(true, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 3, 3, 4, 6, 7, 7, 8, 9 })]
        [TestCase(true, new int[] { -3, -9, -100, 100, 10 }, new int[] { -100, -9, -3, 10, 100 })]
        [TestCase(true, new int[] { 1 }, new int[] { 1 })]
        [TestCase(true, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(true, new int[0], new int[0])]
        [TestCase(false, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 9, 8, 7, 7, 6, 4, 3, 3 })]
        [TestCase(false, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 9, 8, 7, 7, 6, 4, 3, 3 })]
        [TestCase(false, new int[] { -3, -9, -100, 100, 10 }, new int[] { 100, 10, -3, -9, -100 })]
        [TestCase(false, new int[] { 1 }, new int[] { 1 })]
        [TestCase(false, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(false, new int[0], new int[0])]
        public void Sort_WhenCorrectFlagIsPassed_SortsArrayByDescendingOrAscendingOrder(bool flag, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.Sort(flag);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 7, 4, 6, 7, 8, 9, 3 })]
        [TestCase(100, new int[] { -3, -9, -100, 100, 10 }, new int[] { -3, -9, -100, 10 })]
        [TestCase(2, new int[] { 1 }, new int[] { 1 })]
        [TestCase(0, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        public void RemoveFirstByValue_WhenValuePassed_RemoveFirstElementWithGivenValue(int value, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 7, 4, 6, 7, 8, 9 })]
        [TestCase(100, new int[] { -3, 100, -9, -100, 100, 10, 100 }, new int[] { -3, -9, -100, 10 })]
        [TestCase(2, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { })]
        public void RemoveAllByValue_WhenValuePassed_RemoveAllElementsWithGivenValue(int value, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);

            actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[0], new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -1, -2, -3, -4, -5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddList_WhenDoubleLinkedListPassed_AddPassedDoubleLinkedListToDoubleLinkedListTheMethodIsCalledOn(int[] listToAdd, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(listToAdd);

            actual.AddList(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new int[] { 1, 2 })]
        public void AddList_WhenNullPassed_ThrowArgumentNullException(IList array, int[] linkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(linkedList);

            Assert.Throws<ArgumentNullException>(() => list.AddList(array));
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10, 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[0], new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, -4, -5, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5 })]
        public void AddListToStart_WhenDoubleLinkedListPassed_AddPassedDoubleLinkedListToTheStartOfDoubleLinkedListTheMethodIsCalledOn(int[] listToAdd, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(listToAdd);

            actual.AddListToStart(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new int[] { 1, 2 })]
        public void AddListToStart_WhenNullPassed_ThrowArgumentNullException(IList array, int[] linkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(linkedList);

            Assert.Throws<ArgumentNullException>(() => list.AddListToStart(array));
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 6, 7, 8, 9, 10, 4, 5 })]
        [TestCase(new int[] { 6, 7, 8, 9, 10 }, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[0], 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], 0, new int[0], new int[0])]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -1, -2, -3, -4, -5, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5 })]
        public void AddListAtIndex_WhenDoubleLinkedListAndIndexPassed_AddPassedDoubleLinkedListToDoubleLinkedListOnTheGivenIndex(int[] listToAdd, int index, int[] doubleLinkedList, int[] expectedDoubleLinkedList)
        {
            DoubleLinkedList actual = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList expected = DoubleLinkedList.CreateDoubleLinkedList(expectedDoubleLinkedList);
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(listToAdd);

            actual.AddListAtIndex(list, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new int[] { 1, 2 }, 1)]
        public void AddListAtIndex_WhenNullPassed_ThrowArgumentNullException(IList array, int[] linkedList, int index)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(linkedList);

            Assert.Throws<ArgumentNullException>(() => list.AddListAtIndex(array, index));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, new int[] { 1, 2, 3, 4, 5 })]
        public void AddListAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int[] doubleLinkedListToAdd, int index, int[] doubleLinkedList)
        {
            DoubleLinkedList list = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedList);
            DoubleLinkedList listToAdd = DoubleLinkedList.CreateDoubleLinkedList(doubleLinkedListToAdd);

            Assert.Throws<IndexOutOfRangeException>(() => { list.AddListAtIndex(listToAdd, index); });
        }

        [TestCase(0)]
        public void DoubleLinkedListEmptyConstructor_WhenObjectOfAClassIsCreated_LengthEqualsZero(int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList();
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1)]
        public void DoubleLinkedListConstructorWithNValue_WhenObjectIsCreatedWithGivenValue_ListLengthEqualsOne(int value, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(value);
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void DoubleLinkedListConstructorWithArray_WhenNullPassed_ThrowArgumentNullException(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);
            });

        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, 2)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(0, new int[] { 1 }, 1)]
        public void DoubleLinkedListIndexer_WhenLookingForValueByIndex_ReturnValue(int index, int[] array, int expected)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);

            int actual = arrayList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, 9, 9)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, 9, 9)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 9, 9)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 9, 9)]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 9, 9)]
        [TestCase(0, new int[] { 1 }, 9, 9)]
        public void DoubleLinkedListIndexer_WhenChangingValue_ReturnNewValue(int index, int[] array, int newValue, int expected)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);

            array[index] = newValue;
            int actual = array[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 })]
        public void DoubleLinkedListIndexerSet_WhenNegativeIndexOrIndexBiggerOrEqualToLengthIsPassed_ThrowIndexOutOfRangeException(int index, int[] array)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                arrayList[index] = 1;
            });
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 })]
        public void DoubleLinkedListIndexerGet_WhenNegativeIndexOrIndexBiggerOrEqualToLengthIsPassed_ThrowIndexOutOfRangeException(int index, int[] array)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);
            int newValue = 0;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                newValue = arrayList[index];
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, "1 2 3 4 5")]
        [TestCase(new int[] { 1 }, "1")]
        [TestCase(new int[] { }, "")]
        public void ToString_WhenDoubleLinkedListPassed_ReturnItAsAString(int[] array, string expected)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.CreateDoubleLinkedList(array);

            string actual = arrayList.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
