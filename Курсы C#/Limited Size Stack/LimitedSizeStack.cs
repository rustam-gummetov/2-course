using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class Element<T>
    {
        public T Value;
        public Element<T> Next { get; set; }
        public Element<T> Previous { get; set; }
    }

    public class LimitedSizeStack<T>
    {
        public Element<T> head { get; set; }
        public Element<T> tail { get; set; }
        public int ElementCount;
        public int Limit;
        public LimitedSizeStack(int limit)
        {
            Limit = limit;
        }

        public void Push(T item)
        {
            ElementCount++;
            if (head == null)
            {
                head = tail = new Element<T>() { Value = item, Next = null, Previous = null };

            }
            else
            {
                tail.Next = new Element<T>() { Value = item, Next = null, Previous = tail };
                tail = tail.Next;
            }
            if (ElementCount > Limit)
            {
                head = head.Next;
                head.Previous = null;
                ElementCount--;
            }
        }

        public T Pop()
        {
            if (head == null)
                throw new Exception();
            else if (head == tail)
            {
                T result = head.Value;
                head = tail = null;
                ElementCount--;
                return result;
            }
            else
            {
                T result = tail.Value;
                tail.Previous.Next = null;
                tail = tail.Previous;
                ElementCount--;
                return result;
            }
        }

        public int Count
        {
            get
            {
                return ElementCount;
            }
        }
    }
}
