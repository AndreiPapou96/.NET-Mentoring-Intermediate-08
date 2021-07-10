using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Task1
{
    internal class MyContainer<T> : IContainer<T>
    {
        private List<T>  _items;
        public MyContainer(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public IEnumerable<T> Items => _items;

        public int Count => _items.Count;
    }
}
