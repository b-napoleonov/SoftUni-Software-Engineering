using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public int Count { 
            get 
            { 
                return elements.Count;  
            } 
        }

        public void Add (T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T removed = elements.LastOrDefault();

            elements.Remove(removed);

            return removed;
        }
    }
}
