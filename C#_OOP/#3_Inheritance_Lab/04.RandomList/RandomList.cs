using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, Count);
            string str = this[index];
            RemoveAt(index);

            return str;
        }
    }
}
