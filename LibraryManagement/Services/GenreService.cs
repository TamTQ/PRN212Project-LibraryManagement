using LibraryManagement.BusinessObject;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepo _genreService;

        public GenreService()
        {
            _genreService = new GenreRepo();
        }
        public void AddGenre(Genre genre)
        {
            _genreService.AddGenre(genre);
        }

        public void DeleteGenre(int id)
        {
            _genreService.DeleteGenre(id);
        }

        public List<Genre> GetGenres()
        {
           return _genreService.GetGenres();
        }
    }
}
