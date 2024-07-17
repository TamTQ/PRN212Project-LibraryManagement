using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        User Authenticate(string email, string password);
        User GetLoggedInUser();
        void SetLoggedInUser(User user);
    }
}
