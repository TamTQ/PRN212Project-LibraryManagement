using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccessObject
{
    public class GenreDAO
    {
        public static List<Genre> GetGenres()
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Genres.ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error retrieving genres", ex);
            }
        }

        public static void AddGenre(Genre genre)
        {
            try
            {
                using var db = new LibraryManagementContext();
                db.Genres.Add(genre);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error adding genre", ex);
            }
        }

        public static void DeleteGenre(int genreId)
        {
            try
            {
                using var db = new LibraryManagementContext();
                var genre = db.Genres.Find(genreId);
                if (genre != null)
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Genre not found");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error deleting genre", ex);
            }
        }
    }
}
