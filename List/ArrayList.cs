using System;

namespace List
{
    public class ArrayList
    {
        private int[] _array;

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

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[10];

            _array[0] = value;
        }

        public ArrayList(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            Length = array.Length;

            _array = array;

            UpSize();
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
            if(Length == 0)
            {
                throw new Exception("The list is empty");
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
                throw new Exception("The list is empty");
            }
            else
            {
                RemoveAtIndex(0);
            }
        }

        public void RemoveAtIndex(int index)
        {
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
            if(Length >= numberOfElements)
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

        public void ReverseArray()
        {
            int[] tmpArray = new int[_array.Length];
            int count = 0;

            for (int i = Length - 1; i >= 0; i--)
            {
                tmpArray[count] = _array[i];

                ++count;
            }

            _array = tmpArray;
        }

        public int MaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("Array length is 0");
            }
            else
            {
                return _array[MaxValueIndex()];
            }
        }

        public int MinValue()
        {
            if (Length == 0)
            {
                throw new Exception("Array length is 0");
            }
            else
            {
                return _array[MinValueIndex()];
            }
        }

        public int MaxValueIndex()
        {
            if(Length == 0)
            {
                throw new Exception("The list is empty");
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
                throw new Exception("The list is empty");
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

        public void SortAscending()
        {
            for (int i = 0; i < Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[min] > _array[j])
                    {
                        min = j;
                    }
                }

                int temp = _array[i];
                _array[i] = _array[min];
                _array[min] = temp;
            }
        }

        public void SortDescending()
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[max] < _array[j])
                    {
                        max = j;
                    }
                }

                int temp = _array[i];
                _array[i] = _array[max];
                _array[max] = temp;
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

        public void AddArrayList(ArrayList arrayList)
        {
            AddArrayListAtIndex(arrayList, Length);
        }

        public void AddArrayListToStart(ArrayList arrayList)
        {
            AddArrayListAtIndex(arrayList, 0);
        }

        public void AddArrayListAtIndex(ArrayList arrayList, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (arrayList.Length == 0)
            {
                return;
            }

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

        public override string ToString()
        {
            string stringResult = "";

            for (int i = 0; i < Length; i++)
            {
                if (i == Length - 1)
                {
                    stringResult += _array[i];
                }
                else
                {
                    stringResult += _array[i] + " ";
                }
            }

            return stringResult;
        }

        public override bool Equals(object obj)
        {
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
            if (Length >= _array.Length)
            {
                while (Length >= _array.Length)
                {
                    UpSize();
                }
            }
            else if (Length <= _array.Length / 2 + 1)
            {
                DownSize();
            }
        }

        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33 + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.66 + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }


    }
}
