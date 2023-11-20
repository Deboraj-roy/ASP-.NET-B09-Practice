using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class BubbleSort<T>
    {
        public T[] Sort(T[] items, Func<T, T, bool> compare)
        {
            bool flag = true;
            T temp;
            int numLength = items.Length;

            // Bubble sort algorithm
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (compare(items[j + 1], items[j]))
                    {
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        flag = true;
                    }
                }
            }

            return items;
        }
    }
}
