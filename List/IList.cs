using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IList
    {
        public int this[int index] { get; set; }

        public void Add(int value);

        public void AddFirst(int value);

        public void AddAtIndex(int value, int index);

        public void Remove();

        public void RemoveFirst();

        public void RemoveAtIndex(int index);

        public void RemoveNElements(int numberOfElements);

        public void RemoveFirstNElements(int numberOfElements);

        public void RemoveNElementsAtIndex(int numberOfElements, int index);

        public int GetFirstIndexByValue(int value);

        public void Reverse();

        public int MaxValue();

        public int MinValue();

        public int MaxValueIndex();

        public int MinValueIndex();

        public void Sort(bool ascending);

        public void RemoveFirstByValue(int value);

        public void RemoveAllByValue(int value);

        public void AddList(IList list);

        public void AddListToStart(IList list);

        public void AddListAtIndex(IList list, int index);

        public string ToString();

        public bool Equals(object obj);
    }
}
