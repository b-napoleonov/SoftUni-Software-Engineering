using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                Push(element);
            }
        }
    }
}
