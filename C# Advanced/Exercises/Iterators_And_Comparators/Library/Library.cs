using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book> 
    {
        private class LibraryIterator : IEnumerator<Book>
        {
            private  readonly Book[] books;
            private int currentIndex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = books.ToArray();
                Reset();
            }
            public Book Current => books[currentIndex];
            object IEnumerator.Current => Current;
            public void Dispose() { }
            public bool MoveNext()
            {
                return ++currentIndex < books.Length;
            }
            public void Reset()
            {
                currentIndex = -1;
            }
        }
        private readonly SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
