using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        void AddBook(Book book);
        void DeleteBook(int id);
    }
}
