using Kirjakortisto.Context;
using Kirjakortisto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kirjakortisto.Repositories
{
    public interface IBooksRepository : IDisposable
    {
        IQueryable<Book> Books { get; }
        Book Save(Book book);
        void Delete(Book book);
        Book GetById(int id);
    }

    public class BooksRepository : IBooksRepository
    {
        private LibraryContext context = new LibraryContext();

        public IQueryable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }

        public void Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public Book GetById(int id)
        {
            return context.Books.Find(id);
        }

        public Book Save(Book book)
        {
            if (book.Id == 0)
                context.Books.Add(book);
            else
                context.Entry(book).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return book;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BooksRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}