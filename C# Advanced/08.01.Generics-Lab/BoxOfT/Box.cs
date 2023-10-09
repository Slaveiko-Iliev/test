using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<Tclass>
    {
        private Tclass[] array;
        private int count;


        public Box()
        {
            array = new Tclass[4];
            count = 0;
        }

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }


        public void Add(Tclass element)
        {
            Resize();

            Tclass[] copy = new Tclass[array.Length];

            if (Count == 0)
            {
                copy[0] = element;
                Count++;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    copy[i + 1] = array[i];
                }
                copy[0] = element;


                Count++;
            }

            array = copy;
        }
        public Tclass Remove()
        {
            Tclass[] copy = new Tclass[array.Length];

            Tclass removedElement = array[0];

            for (int i = 0; i < Count - 1; i++)
            {
                copy[i] = array[i + 1];
            }

            array = copy;
            Count--;

            return removedElement;
        }

        private void Resize()
        {
            Tclass[] copy = new Tclass[array.Length];

            if (Count == array.Length)
            {
                copy = new Tclass[array.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    copy[0] = array[0];
                }
                array = copy;
            }


        }
    }
}
