using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex30_LinkedList
{
    public class LinkedList : IEnumerable
    {
        private class ListItem
        {
            public object Item { get; }
            public ListItem Next { get; set; }

            public ListItem(object o)
            {
                Item = o;
            }

            public override string ToString()
            {
                return Item.ToString(); 
            }
        }

        private class LinkedListEnumerator : IEnumerator
        {
            public object Current
            {
                get
                {

                }
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        private ListItem firstItem = null;
        private ListItem lastItem = null;
        private int itemCount = 0;

        public object First { get { return firstItem?.Item; } }
        public object Last { get { return lastItem?.Item; } }
        public int Count { get { return itemCount; } }

        public object Items(int index)
        {
            if (index < 0 ||itemCount < index)
                throw new ArgumentOutOfRangeException();

            ListItem r = firstItem;
            for(int i = 0; i < index; i++)
            {
                    r = r.Next;
            }
            return r.Item;
        }

        public void InsertFirst(object o)
        {
            ListItem newItem = new ListItem(o);
            newItem.Next = firstItem;
            firstItem = newItem;
            if (itemCount == 0)
                lastItem = newItem;
            itemCount++;
        }

        public void InsertLast(object o)
        {
            ListItem newItem = new ListItem(o);
            if (lastItem != null)
                lastItem.Next = newItem;
            lastItem = newItem;
            if (itemCount == 0)
                firstItem = newItem;
            itemCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || itemCount < index)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                firstItem = firstItem.Next;
            }
            else
            {
                ListItem r = firstItem;
                for (int i = 1; i < index; i++)
                {
                    r = r.Next;
                }
                if (index == itemCount - 1)
                {
                    r.Next = null;
                    lastItem = r;
                }
                else
                {
                    r.Next = r.Next.Next;
                }
            }
            
            

            
            itemCount--;
        }

        public override string ToString()
        {
            ListItem item = firstItem;
            ListItem[] items = new ListItem[itemCount];
            items[0] = item;
            for(int i = 1; i < itemCount; i++)
            {
                item = item.Next;
                items[i] = item;
            }
            return String.Join("|", items.Select(x => x.ToString()));
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumerator();
        }
    }
}
