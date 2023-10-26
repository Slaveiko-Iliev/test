using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private int _index;

        public ListyIterator(List<T> collection)
        {
            Collection = collection;
        }
            
        public List<T> Collection { get; private set; }


        public bool Move()
        {
            if (_index < Collection.Count - 1)
            {
                _index++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
        {
            return _index + 1 < Collection.Count;
        }

        public void Print()
        {
            if (Collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
            Console.WriteLine(Collection[_index]);
        }
    }
}
