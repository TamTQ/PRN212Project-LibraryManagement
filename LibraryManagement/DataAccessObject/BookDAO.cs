using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccessObject
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Books.Include(b => b.Genre).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error retrieving books", ex);
            }
        }

            public static void AddBook(Book book)
            {
                try
                {
                    using var db = new LibraryManagementContext();
                    db.Genres.Attach(book.Genre);
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, rethrow it, etc.)
                    throw new Exception("Error adding book", ex);
                }
            }

        public static void DeleteBook(int bookId)
        {
            try
            {
                using var db = new LibraryManagementContext();
                var book = db.Books.Find(bookId);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Book not found");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error deleting book", ex);
            }
        }
    }
}
