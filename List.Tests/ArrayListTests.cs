using NUnit.Framework;
using System;

namespace List.Tests
{
    public class Tests
    {
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 10 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10 })]
        [TestCase(-10, new int[] { }, new int[] { -10 })]
        public void Add_WhenValuePassed_AddThisValueToTheEndOfTheList(int value, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenValuePassed_AddThisValueOnTheFisrtPosition(int value, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 2, 3, 4, 5 })]
        [TestCase(0, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 0, 3, 4, 5 })]
        [TestCase(-10, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, -10, 4, 5 })]
        [TestCase(-10, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10 })]
        [TestCase(-10, 0, new int[] { 1 }, new int[] { -10, 1 })]
        [TestCase(-10, 1, new int[] { 1 }, new int[] { 1, -10 })]
        public void AddAtIndex_WhenValuePassed_AddThisValueOnTheGivenIndex(int value, int index, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.AddAtIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(10, -1, new int[] { 1, 2, 3, 4, 5 })]
        public void AddAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int value, int index, int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.AddAtIndex(value, index); });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void Remove_WhenCalled_RemoveAValueFromTheEndOfTheList(int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void Remove_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.Remove(); });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirst_WhenCalled_RemoveAValueFromTheStartOfTheList(int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void RemoveFirst_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.RemoveFirst(); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5 })]
        [TestCase(0, new int[] { 1 }, new int[] { })]
        public void RemoveAtIndex_WhenIndexPassed_RemoveAValueOnTheGivenIndex(int index, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.RemoveAtIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { })]
        [TestCase(1, new int[] { })]
        public void RemoveAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int index, int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAtIndex(index); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(0, new int[] { }, new int[] { })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { }, new int[] { })]
        public void RemoveNElements_WhenNumberOfElementsPassed_RemoveNElemetsFromTheEndOfTheList(int numberOfElements, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.RemoveNElements(numberOfElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        public void RemoveFirstNElements_WhenNumberOfElementsPassed_RemoveNElemetsFromTheStartOfTheList(int numberOfElements, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.RemoveFirstNElements(numberOfElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 4, 5 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(5, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(7, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        public void RemoveNElementsAtIndex_WhenNumberOfElementsPassed_RemoveNElemetsFromTheStartOfTheList(int numberOfElements, int index, int[] arrayList, int[] expectedArrayList)
        {
            ArrayList actual = new ArrayList(arrayList);
            ArrayList expected = new ArrayList(expectedArrayList);

            actual.RemoveNElementsAtIndex(numberOfElements, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, -1, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveNElementsAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int numberOfElements, int index, int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveNElementsAtIndex(numberOfElements, index); });
        }

        [TestCase(1, new int[] { 1, 2, 3, 1, 4, 5, 1 }, 0)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, -1)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(-1, new int[] { 1, 2, 3, 4, -1, 5 }, 4)]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5 }, -1)]
        public void GetFirstIndexByValue_WhenValuePassed_ReturnIndexOfTheElementsWithGivenValue(int value, int[] arrayList, int expected)
        {
            ArrayList list = new ArrayList(arrayList);

            int actual = list.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 1, 0, 0 })]
        [TestCase(new int[] { -1, 2, -3, 4, -5 }, new int[] { -5, 4, -3, 2, -1 })]
        [TestCase(new int[] { -1 }, new int[] { -1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_WhenCalled_ReverseArrayItsCalledOn(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

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
            ArrayList list = new ArrayList(array);

            int actual = list.MaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MaxValue_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.MaxValue(); });
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 3)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, -100)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 1)]
        public void MinValue_WhenCalled_ReturnTheMinValueOfTheArray(int[] array, int expected)
        {
            ArrayList list = new ArrayList(array);

            int actual = list.MinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MinValue_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.MinValue(); });
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 6)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, 3)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0)]
        [TestCase(new int[] { 10, 100, 10, 11 }, 1)]
        public void MaxValueIndex_WhenCalled_ReturnTheMaxValueIndex(int[] array, int expected)
        {
            ArrayList list = new ArrayList(array);

            int actual = list.MaxValueIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MaxValueIndex_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.MaxValueIndex(); });
        }

        [TestCase(new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, 0)]
        [TestCase(new int[] { -3, -9, -100, 100, 10 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0)]
        public void MinValueIndex_WhenCalled_ReturnTheMinValueIndex(int[] array, int expected)
        {
            ArrayList list = new ArrayList(array);

            int actual = list.MinValueIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void MinValueIndex_WhenUsedOnZeroLengthArray_ThrowException(int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<Exception>(() => { list.MinValueIndex(); });
        }

        [TestCase("a", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 3, 3, 4, 6, 7, 7, 8, 9 })]
        [TestCase("A", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 3, 3, 4, 6, 7, 7, 8, 9 })]
        [TestCase("a", new int[] { -3, -9, -100, 100, 10 }, new int[] { -100, -9, -3, 10, 100 })]
        [TestCase("a", new int[] { 1 }, new int[] { 1 })]
        [TestCase("a", new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase("a", new int[0], new int[0])]
        [TestCase("d", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 9, 8, 7, 7, 6, 4, 3, 3 })]
        [TestCase("D", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 9, 8, 7, 7, 6, 4, 3, 3 })]
        [TestCase("d", new int[] { -3, -9, -100, 100, 10 }, new int[] { 100, 10, -3, -9, -100 })]
        [TestCase("d", new int[] { 1 }, new int[] { 1 })]
        [TestCase("d", new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase("d", new int[0], new int[0])]
        public void Sort_WhenCorrectFlagIsPassed_SortsArrayByDescendingOrAscendingOrder(string flag, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Sort(flag);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("q", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 })]
        [TestCase("ad", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 })]
        [TestCase("da", new int[] { 3, 7, 4, 6, 7, 8, 9, 3 })]
        public void Sort_WhenIncorrectFlagIsPassed_ThrowArgumentException(string flag, int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);

            Assert.Throws<ArgumentException>(() => { list.Sort(flag); });
        }

        [TestCase(3, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 7, 4, 6, 7, 8, 9, 3 })]
        [TestCase(100, new int[] { -3, -9, -100, 100, 10 }, new int[] { -3, -9, -100, 10 })]
        [TestCase(2, new int[] { 1 }, new int[] { 1 })]
        [TestCase(0, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
        public void RemoveFirstByValue_WhenValuePassed_RemoveFirstElementWithGivenValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 3, 7, 4, 6, 7, 8, 9, 3 }, new int[] { 7, 4, 6, 7, 8, 9 })]
        [TestCase(100, new int[] { -3, 100, -9, -100, 100, 10, 100 }, new int[] { -3, -9, -100, 10 })]
        [TestCase(2, new int[] { 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { })]
        public void RemoveAllByValue_WhenValuePassed_RemoveAllElementsWithGivenValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -1, -2, -3, -4, -5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddArrayList_WhenArrayListPassed_AddPassedArrayListToArrayListTheMethodIsCalledOn(int[] listToAdd, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList list = new ArrayList(listToAdd);

            actual.AddArrayList(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10, 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, -4, -5, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5 })]
        public void AddArrayListToStart_WhenArrayListPassed_AddPassedArrayListToTheStartOfArrayListTheMethodIsCalledOn(int[] listToAdd, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList list = new ArrayList(listToAdd);

            actual.AddArrayListToStart(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10 }, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 6, 7, 8, 9, 10, 4, 5 })]
        [TestCase(new int[0], 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -1, -2, -3, -4, -5, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5 })]
        public void AddArrayListAtIndex_WhenArrayListAndIndexPassed_AddPassedArrayListToArrayListOnTheGivenIndex(int[] listToAdd, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList list = new ArrayList(listToAdd);

            actual.AddArrayListAtIndex(list, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, new int[] { 1, 2, 3, 4, 5 })]
        public void AddArrayListAtIndex_WhenIndexIsLessThanZeroOrBiggerThanArrayLength_ThrowIndexOutOfRangeException(int[] arrayListToAdd, int index, int[] arrayList)
        {
            ArrayList list = new ArrayList(arrayList);
            ArrayList listToAdd = new ArrayList(arrayListToAdd);

            Assert.Throws<IndexOutOfRangeException>(() => { list.AddArrayListAtIndex(listToAdd, index); });
        }
    }
}