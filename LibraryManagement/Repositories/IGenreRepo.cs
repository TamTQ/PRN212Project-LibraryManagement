using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public interface IGenreRepo
    {
        List<Genre> GetGenres();
        void AddGenre(Genre genre);
        void DeleteGenre(int id);
    }
}
