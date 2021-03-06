using System;
using System.Text;

namespace List
{
    public class LinkedList : IList
    {
        private Node _root { get; set; }
        private Node _tail { get; set; }
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = _root;

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

                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }

        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        private LinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }

        }

        public static LinkedList CreateLinkedList(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                LinkedList linkedList = new LinkedList(array);

                return linkedList;
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }

            ++Length;
        }

        public void AddFirst(int value)
        {
            ++Length;

            Node newNode = new Node(value);
            newNode.Next = _root;
            _root = newNode;
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
                Node newNode = new Node(value);
                Node tmp = GetNodeByIndex(index - 1);

                newNode.Next = tmp.Next;
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

                Node tmp = GetNodeByIndex(indexOfNodeBeforeTail);

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
                Node tmp = GetNodeByIndex(index - 1);

                tmp.Next = tmp.Next.Next;

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
                Node tmp = GetNodeByIndex(numberOfElements);

                _root = tmp;

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
                Node tmp1 = GetNodeByIndex(index - 1);
                Node tmp2 = GetNodeByIndex(index + numberOfElements - 1);

                tmp1.Next = tmp2.Next;

                Length = Length - numberOfElements;
            }

        }

        public int GetFirstIndexByValue(int value)
        {
            int index = 0;

            while (index < Length)
            {
                Node current = GetNodeByIndex(index);

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
            Node prev = null;
            Node current = _root;

            while (!(current is null))
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            _tail = _root;
            _root = prev;
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
                    Node current = GetNodeByIndex(maxIndex);
                    Node next = GetNodeByIndex(i);

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
                    Node current = GetNodeByIndex(minIndex);
                    Node next = GetNodeByIndex(i);

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
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            LinkedList linkedList = (LinkedList)list;

            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                Length = Length + linkedList.Length;

                Node tmp = _tail;
                tmp.Next = linkedList._root;
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

            LinkedList linkedList = (LinkedList)list;

            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                Length = Length + linkedList.Length;

                Node oldRoot = _root;
                Node oldTail = linkedList._tail;

                oldTail.Next = oldRoot;
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

            LinkedList linkedList = (LinkedList)list;

            if (this._root is null || linkedList._root is null)
            {
                if (linkedList._root is null)
                {
                    return;
                }
                else
                {
                    this._root = linkedList._root;
                    Length = Length + linkedList.Length;
                }
            }
            else if (index == 0)
            {
                AddListToStart(linkedList);
            }
            else if (index == Length)
            {
                AddList(linkedList);
            }
            else
            {
                Node previous = GetNodeByIndex(index - 1);
                Node next = GetNodeByIndex(index);

                previous.Next = linkedList._root;
                linkedList._tail.Next = next;

                Length = Length + linkedList.Length;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                result.Append(current.Value + " ");
                current = current.Next;
            }

            return result.ToString().TrimEnd();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }

            LinkedList list = (LinkedList)obj;
            bool result = true;

            if (this.Length != list.Length)
            {
                result = false;
            }

            Node currentThis = _root;
            Node currentList = list._root;

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
            }

            return result;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _root;
            int count = 0;

            while (count != index)
            {
                tmp = tmp.Next;

                ++count;
            }

            return tmp;
        }
    }
}
