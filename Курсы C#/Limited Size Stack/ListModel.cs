using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class Add<T>
    {
        public T Str;
    }

    public class Remove<T>
    {
        public int Index;
        public T Str;
    }

    public class Value<T>
    {
        public string Act { get; set; }
        public T Str { get; set; }
        public int Index { get; set; }
    }

    public class ListModel<TItem>
    {      
        public List<TItem> Items { get; }
        public int Limit;

        public Add<TItem> AddLast;
        public Remove<TItem> RemoveLast;  
        public int IndexLast;
        LimitedSizeStack<TItem> stack;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            stack = new LimitedSizeStack<TItem>(limit);
        }
        public void AddInMiddle(TItem item, int index)
        {
            AddLast = new Add<TItem> { Str = item };
            RemoveLast = null;
            Items.Insert(index, item);
            IndexLast = index;
        }
        public void AddItem(TItem item)
        {
            var V = new Value<TItem> { Act = "push", Str = item, Index = Items.Count - 1 };
            stack.Push(V);
            AddLast = new Add<TItem> { Str = item };           
            RemoveLast = null;         
            Items.Add(item);
            IndexLast = Items.Count - 1;
        }

        public void RemoveItem(int index)
        {
            RemoveLast = new Remove<TItem> { Index = index, Str = Items[index] };
            AddLast = null;
            Items.RemoveAt(index);
            IndexLast = index;
        }

        public bool CanUndo()
        {
            return AddLast != null || RemoveLast != null;
        }

        public void Undo()
        {
            if (AddLast != null)
            {
                RemoveItem(IndexLast);
            }
            else
            {
                AddInMiddle(RemoveLast.Str, RemoveLast.Index);
            }
        }
    }
}
