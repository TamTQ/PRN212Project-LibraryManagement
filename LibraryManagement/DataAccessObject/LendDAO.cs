using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccessObject
{
    public class LendDAO
    {
        public static List<Lend> GetLends()
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Lends.Include(l => l.Book).Include(l => l.User).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error retrieving lends", ex);
            }
        }

        public static List<Lend> GetLendByUserId(int userId)
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Lends.Include(l => l.Book).Include(l => l.User).Where(l => l.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception($"Error retrieving lends by user ID: {userId}", ex);
            }
        }

        public static void AddLend(Lend lend)
        {
            try
            {
                using var db = new LibraryManagementContext();
                db.Lends.Add(lend);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error adding lend", ex);
            }
        }

        public static void UpdateLendReturnDate(int lendId, DateOnly returnDate)
        {
            try
            {
                using var db = new LibraryManagementContext();
                var lend = db.Lends.Find(lendId);
                if (lend != null)
                {
                    lend.ReturnDate = returnDate;
                    db.Lends.Update(lend);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Lend not found");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error updating return date", ex);
            }
        }
    }
}
