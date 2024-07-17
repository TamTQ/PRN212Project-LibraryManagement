using LibraryManagement.BusinessObject;
using LibraryManagement.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class GenreRepo : IGenreRepo
    {
        public void AddGenre(Genre genre) => GenreDAO.AddGenre(genre);

        public void DeleteGenre(int id) => GenreDAO.DeleteGenre(id);

        public List<Genre> GetGenres() => GenreDAO.GetGenres();
    }
}
