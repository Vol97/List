using System;
using System.Text;

namespace List
{
    public class DoubleLinkedList : IList
    {
        private DoubleLinkedNode _root { get; set; }
        private DoubleLinkedNode _tail { get; set; }
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                DoubleLinkedNode current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }

            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                DoubleLinkedNode current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }

        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleLinkedNode(value);
            _tail = _root;
        }

        private DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleLinkedNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DoubleLinkedNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }

        }

        public static DoubleLinkedList CreateDoubleLinkedList(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                DoubleLinkedList linkedList = new DoubleLinkedList(array);

                return linkedList;
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new DoubleLinkedNode(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new DoubleLinkedNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }

            ++Length;
        }

        public void AddFirst(int value)
        {
            if (Length != 0)
            {
                DoubleLinkedNode newNode = new DoubleLinkedNode(value);
                _root.Previous = newNode;
                newNode.Next = _root;
                _root = newNode;
            }
            else
            {
                _root = new DoubleLinkedNode(value);
                _tail = _root;
            }

            ++Length;
        }

        public void AddAtIndex(int value, int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                DoubleLinkedNode newNode = new DoubleLinkedNode(value);
                DoubleLinkedNode tmp = GetNodeByIndex(index - 1);

                newNode.Next = tmp.Next;
                newNode.Previous = tmp;
                tmp.Next.Previous = newNode;
                tmp.Next = newNode;

                ++Length;
            }
        }

        public void Remove()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (Length == 1)
            {
                _root = null;
            }
            else
            {
                int indexOfNodeBeforeTail = Length - 2;

                DoubleLinkedNode tmp = GetNodeByIndex(indexOfNodeBeforeTail);

                tmp.Next = null;

                _tail = tmp;
            }

            --Length;
        }

        public void RemoveFirst()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (Length == 1)
            {
                _root = null;
            }
            else
            {
                _root = _root.Next;
            }

            --Length;
        }

        public void RemoveAtIndex(int index)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == Length - 1)
            {
                Remove();
            }
            else if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                DoubleLinkedNode tmp = GetNodeByIndex(index - 1);

                tmp.Next = tmp.Next.Next;
                tmp.Next.Previous = tmp;

                --Length;
            }
        }

        public void RemoveNElements(int numberOfElements)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (Length > numberOfElements)
            {
                Length = Length - numberOfElements;

                _tail = GetNodeByIndex(Length - 1);
                _tail.Next = null;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void RemoveFirstNElements(int numberOfElements)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (Length > numberOfElements)
            {
                DoubleLinkedNode tmp = GetNodeByIndex(numberOfElements);

                _root = tmp;
                _root.Previous = null;

                Length = Length - numberOfElements;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void RemoveNElementsAtIndex(int numberOfElements, int index)
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                RemoveFirstNElements(numberOfElements);
            }
            else if (index + numberOfElements > Length)
            {
                RemoveNElements(Length - index);
            }
            else
            {
                DoubleLinkedNode tmp1 = GetNodeByIndex(index - 1);
                DoubleLinkedNode tmp2 = GetNodeByIndex(index + numberOfElements - 1);

                tmp1.Next = tmp2.Next;
                tmp1.Next.Previous = tmp1;

                Length = Length - numberOfElements;
            }

        }

        public int GetFirstIndexByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                DoubleLinkedNode current = GetNodeByIndex(index);

                if (current.Value == value)
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
            DoubleLinkedNode current = _root;
            DoubleLinkedNode tmp = _tail;
            int value;
            int count = 0;

            while (count != Length / 2)
            {
                value = current.Value;
                current.Value = tmp.Value;
                tmp.Value = value;

                current = current.Next;
                tmp = tmp.Previous;

                ++count;
            }
        }

        public int MaxValue()
        {
                return GetNodeByIndex(MaxValueIndex()).Value;
        }

        public int MinValue()
        {
                return GetNodeByIndex(MinValueIndex()).Value;
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
                    DoubleLinkedNode current = GetNodeByIndex(maxIndex);
                    DoubleLinkedNode next = GetNodeByIndex(i);

                    if (current.Value < next.Value)
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
                    DoubleLinkedNode current = GetNodeByIndex(minIndex);
                    DoubleLinkedNode next = GetNodeByIndex(i);

                    if (current.Value > next.Value)
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
                int minValue = GetNodeByIndex(i).Value;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(j).Value.CompareTo(minValue) == coef)
                    {
                        minIndex = j;
                        minValue = GetNodeByIndex(j).Value;
                    }
                }

                GetNodeByIndex(minIndex).Value = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = minValue;
            }
        }

        public void RemoveFirstByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                if (GetNodeByIndex(index).Value == value)
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
                if (GetNodeByIndex(index).Value == value)
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
            if(list is null)
            {
                throw new ArgumentNullException();
            }

            DoubleLinkedList linkedList = (DoubleLinkedList)list;

            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                Length = Length + linkedList.Length;

                DoubleLinkedNode tmp = _tail;
                tmp.Next = linkedList._root;
                linkedList._root.Previous = tmp;
                _tail = linkedList._tail;
            }
            else if (this._root is null)
            {
                if (linkedList._root is null)
                {
                    return;
                }
                else
                {
                    Length = Length + linkedList.Length;
                    this._root = linkedList._root;
                    this._tail = linkedList._tail;
                }
            }
            else
            {
                return;
            }

        }

        public void AddListToStart(IList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            DoubleLinkedList linkedList = (DoubleLinkedList)list;

            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                Length = Length + linkedList.Length;

                DoubleLinkedNode oldRoot = _root;
                DoubleLinkedNode oldTail = linkedList._tail;

                oldTail.Next = oldRoot;
                oldRoot.Previous = oldTail;
                _root = linkedList._root;
            }
            else if (this._root is null)
            {
                if (linkedList._root is null)
                {
                    return;
                }
                else
                {
                    Length = Length + linkedList.Length;
                    this._root = linkedList._root;
                    this._tail = linkedList._tail;
                }
            }
            else
            {
                return;
            }
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

            DoubleLinkedList linkedList = (DoubleLinkedList)list;

            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                if (index == 0)
                {
                    AddListToStart(linkedList);
                }
                else if (index == Length)
                {
                    AddList(linkedList);
                }
                else
                {
                    DoubleLinkedNode previous = GetNodeByIndex(index - 1);
                    DoubleLinkedNode next = GetNodeByIndex(index);

                    previous.Next = linkedList._root;
                    linkedList._root.Previous = previous;
                    linkedList._tail.Next = next;
                    next.Previous = linkedList._tail;

                    Length = Length + linkedList.Length;
                }
            }
            else if (this._root is null)
            {
                if (linkedList._root is null)
                {
                    return;
                }
                else
                {
                    Length = Length + linkedList.Length;
                    this._root = linkedList._root;
                    this._tail = linkedList._tail;
                }
            }
            else
            {
                return;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (Length != 0)
            {
                DoubleLinkedNode current = _root;
                result.Append(current.Value + " ");

                while (!(current.Next is null))
                {
                    current = current.Next;
                    result.Append(current.Value + " ");
                }
            }

            return result.ToString().TrimEnd();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }

            DoubleLinkedList list = (DoubleLinkedList)obj;
            bool result = true;

            if (this.Length != list.Length)
            {
                result = false;
            }

            DoubleLinkedNode currentThis = _root;
            DoubleLinkedNode currentList = list._root;

            if (Length == 0)
            {
                result = true;
            }
            else if (Length == 1)
            {
                if (currentThis.Value != currentList.Value)
                {
                    result = false;
                }
            }
            else
            {
                do
                {
                    if (currentThis.Value != currentList.Value)
                    {
                        result = false;
                    }
                    currentThis = currentThis.Next;
                    currentList = currentList.Next;
                }
                while (!(currentThis.Next is null));

                currentThis = _tail;
                currentList = list._tail;

                do
                {
                    if (currentThis.Value != currentList.Value)
                    {
                        result = false;
                    }
                    currentThis = currentThis.Previous;
                    currentList = currentList.Previous;
                }
                while (!(currentThis.Previous is null));
            }

            return result;
        }

        private DoubleLinkedNode GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            DoubleLinkedNode tmp = _root;
            int count = 0;

            if (index > Length / 2 + 1)
            {
                count = Length - 1;
                tmp = _tail;

                while (count != index)
                {
                    tmp = tmp.Previous;

                    --count;
                }
            }
            else
            {
                while (count != index)
                {
                    tmp = tmp.Next;

                    ++count;
                }
            }

            return tmp;
        }
    }
}
