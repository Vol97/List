using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedNode
    {
        public int Value { get; set; }
        public DoubleLinkedNode Next { get; set; }
        public DoubleLinkedNode Previous { get; set; }

        public DoubleLinkedNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(Value);

            return result.ToString();
        }
    }
}
