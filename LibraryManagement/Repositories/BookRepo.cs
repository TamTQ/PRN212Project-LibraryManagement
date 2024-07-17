using LibraryManagement.BusinessObject;
using LibraryManagement.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class BookRepo : IBookRepo
    {
        public void AddBook(Book book) => BookDAO.AddBook(book);

        public void DeleteBook(int id) => BookDAO.DeleteBook(id);

        public List<Book> GetBooks() => BookDAO.GetBooks();
    }
}
