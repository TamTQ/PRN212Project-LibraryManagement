using LibraryManagement.BusinessObject;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookService;

        public BookService()
        {
            _bookService = new BookRepo();
        }
        public void AddBook(Book book)
        {
            _bookService.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        public List<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }
    }
}
