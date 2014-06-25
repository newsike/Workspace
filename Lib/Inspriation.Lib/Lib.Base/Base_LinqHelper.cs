using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Inspriation.Lib
{
    public class Base_LinqHelper<T> : IEnumerable<T>, IEnumerable
    {
        IEnumerable items;

        public Base_LinqHelper(IEnumerable items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }            
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            IEnumerable<T> ie = this;
            return ie.GetEnumerator();            
        }
    }
}
