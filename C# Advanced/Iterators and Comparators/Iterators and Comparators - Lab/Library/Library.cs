using System.Collections;
using System.Collections.Generic;
using IteratorsAndComparators;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort(new BookComparator());
        }

        IEnumerator<Book> IEnumerable<Book>.GetEnumerator()
        {
            return new LibraryIterator(this.books);

            //foreach (var book in this.books)
            //{
            //     yield return book;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.books.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex;
            private readonly List<Book> books;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current
            {
                get { return this.books[this.currentIndex]; } 
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

        }
    }
}
