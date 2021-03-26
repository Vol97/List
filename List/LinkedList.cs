using System;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }
        private Node _root { get; set; }
        private Node _tail { get; set; }

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

        public LinkedList(int[] values)
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
                throw new Exception("The list is empty");
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
                throw new Exception("The list is empty");
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

        public void ReverseArray()
        {
            
        }

        public int MaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("Array length is 0");
            }
            else
            {
                Node res = GetNodeByIndex(MaxValueIndex());

                return res.Value;
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
                Node res = GetNodeByIndex(MinValueIndex());

                return res.Value;
            }
        }

        public int MaxValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("The list is empty");
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
                throw new Exception("The list is empty");
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

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
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

        public override string ToString()
        {
            string result = string.Empty;

            if (Length != 0)
            {
                Node current = _root;
                result = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    result += current.Value + " ";
                }
            }

            return result;

        }

        public override bool Equals(object obj)
        {
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
    }
}
