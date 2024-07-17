using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccessObject
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Users.Include(u => u.Lends).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error retrieving users", ex);
            }
        }

        public static User GetUserByEmail(string email)
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Users.Include(u => u.Lends).FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception($"Error retrieving user by email: {email}", ex);
            }
        }

        public static User GetUserById(int userId)
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Users.Include(u => u.Lends).FirstOrDefault(u => u.UserId == userId);
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception($"Error retrieving user by ID: {userId}", ex);
            }
        }

        public static void AddUser(User user)
        {
            try
            {
                using var db = new LibraryManagementContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error adding user", ex);
            }
        }

        public static void EditUser(User user)
        {
            try
            {
                using var db = new LibraryManagementContext();
                var existingUser = db.Users.Find(user.UserId);
                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;

                    db.Users.Update(existingUser);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error editing user", ex);
            }
        }

        public static void DeleteUser(int userId)
        {
            try
            {
                using var db = new LibraryManagementContext();
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("Error deleting user", ex);
            }
        }
    }
}
