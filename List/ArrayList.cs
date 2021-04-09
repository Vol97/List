using System;
using System.Text;

namespace List
{
    public class ArrayList : IList
    {
        private int[] _array;
        private const int _basicArrayLength = 10;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;

            _array = new int[_basicArrayLength];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[_basicArrayLength];

            _array[0] = value;
        }

        private ArrayList(int[] array)
        {
            Length = array.Length;

            _array = array;

            CheckAndChangeSize();
        }

        public static ArrayList CreateArrayList(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new ArrayList(array);
            }
        }

        public void Add(int value)
        {
            AddAtIndex(value, Length);
        }

        public void AddFirst(int value)
        {
            AddAtIndex(value, 0);
        }

        public void AddAtIndex(int value, int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            CheckAndChangeSize();

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;

            ++Length;
        }

        public void Remove()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                --Length;

                CheckAndChangeSize();
            }
        }

        public void RemoveFirst()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                RemoveAtIndex(0);
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            --Length;

            CheckAndChangeSize();
        }

        public void RemoveNElements(int numberOfElements)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (Length >= numberOfElements)
            {
                Length = Length - numberOfElements;
            }
            else
            {
                Length = 0;
            }

            CheckAndChangeSize();
        }

        public void RemoveFirstNElements(int numberOfElements)
        {
            RemoveNElementsAtIndex(numberOfElements, 0);
        }

        public void RemoveNElementsAtIndex(int numberOfElements, int index)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (numberOfElements >= Length)
            {
                Length = Length - (Length - index);

                CheckAndChangeSize();
            }
            else if (numberOfElements == 0)
            {
                return;
            }
            else
            {
                for (int i = index; i < Length; i++)
                {
                    if (i + numberOfElements >= Length)
                    {
                        break;
                    }

                    _array[i] = _array[i + numberOfElements];
                }

                if (Length - index < numberOfElements)
                {
                    Length = Length - (Length - index);
                }
                else
                {
                    Length = Length - numberOfElements;
                }

                CheckAndChangeSize();
            }
        }

        public int GetFirstIndexByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                if (_array[index] == value)
                {
                    return index;
                }
                else
                {
                    ++index;
                }
            }

            return -1;
        }

        public void Reverse()
        {
            int tmp = 0;
            int lastIndex = Length - 1;
            int count = 0;

            while (count != Length / 2)
            {
                tmp = _array[count];
                _array[count] = _array[lastIndex];
                _array[lastIndex] = tmp;

                ++count;
                --lastIndex;
            }
        }

        public int MaxValue()
        {
            return _array[MaxValueIndex()];
        }

        public int MinValue()
        {
            return _array[MinValueIndex()];
        }

        public int MaxValueIndex()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                int maxIndex = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[maxIndex] < _array[i])
                    {
                        maxIndex = i;
                    }
                }

                return maxIndex;
            }
        }

        public int MinValueIndex()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                int minIndex = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[minIndex] > _array[i])
                    {
                        minIndex = i;
                    }
                }

                return minIndex;
            }
        }
        /// <summary>
        /// Ascending/Descending sort
        /// </summary>
        /// <param name="ascending">Should be true or false bool, for ascending or descending sort order respectively</param>
        public void Sort(bool ascending)
        {
            int coef = ascending ? -1 : 1;

            for (int i = 0; i < Length; i++)
            {
                int minIndex = i;
                int minValue = _array[i];

                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j].CompareTo(minValue) == coef)
                    {
                        minIndex = j;
                        minValue = _array[j];
                    }
                }

                _array[minIndex] = _array[i];
                _array[i] = minValue;
            }
        }

        public void RemoveFirstByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                if (_array[index] == value)
                {
                    RemoveAtIndex(index);
                    return;
                }
                else
                {
                    ++index;
                }
            }
        }

        public void RemoveAllByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                if (_array[index] == value)
                {
                    RemoveAtIndex(index);
                }
                else
                {
                    ++index;
                }
            }
        }

        public void AddList(IList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            ArrayList arrayList = (ArrayList)list;

            AddListAtIndex(arrayList, Length);
        }

        public void AddListToStart(IList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            ArrayList arrayList = (ArrayList)list;

            AddListAtIndex(arrayList, 0);
        }

        public void AddListAtIndex(IList list, int index)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            ArrayList arrayList = (ArrayList)list;

            if (arrayList.Length == 0)
            {
                return;
            }
            else
            {
                Length = Length + arrayList.Length;

                CheckAndChangeSize();

                int count = 0;

                for (int i = index; i < Length; i++)
                {
                    if (i + arrayList.Length < _array.Length)
                    {
                        _array[i + arrayList.Length] = _array[i];
                    }
                    if (count < arrayList.Length)
                    {
                        _array[i] = arrayList[count];
                    }

                    ++count;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                if (i == Length - 1)
                {
                    result.Append(_array[i]);
                }
                else
                {
                    result.Append(_array[i] + " ");
                }
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }

            ArrayList list = (ArrayList)obj;

            bool result = true;

            if (this.Length != list.Length)
            {
                result = false;
            }
            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != list._array[i])
                {
                    result = false;
                }
            }

            return result;
        }

        private void CheckAndChangeSize()
        {
            int newLength = Length >= _array.Length ? (int)(_array.Length * 1.33 + 1) : (int)(_array.Length * 0.66 + 1);
            int[] tmpArray = new int[newLength];

            if (Length >= _array.Length)
            {
                while (Length >= _array.Length)
                {
                    newLength = (int)(_array.Length * 1.33 + 1);

                    tmpArray = new int[newLength];

                    for (int i = 0; i < _array.Length; i++)
                    {
                        tmpArray[i] = _array[i];
                    }

                    _array = tmpArray;
                }
            }
            else if (Length <= _array.Length / 2 + 1)
            {
                for (int i = 0; i < Length; i++)
                {
                    tmpArray[i] = _array[i];
                }

                _array = tmpArray;
            }
        }
    }
}
