using System;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        private readonly T Left;
        private readonly T Right;

        public bool AreEqual()
        {
            return Left.Equals(Right);
        }
    }
}
