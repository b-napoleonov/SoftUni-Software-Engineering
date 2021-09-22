using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;
        public Library(params Book[] _books)
        {
            books = new SortedSet<Book>(_books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IList<Book> books;

            private int index;
            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public LibraryIterator(IEnumerable<Book> _books)
            {
                Reset();
                books = new List<Book>(_books);
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
