using LibraryManagement.BusinessObject;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userService;
        private User _loggedInUser;

        public UserService()
        {
            _userService = new UserRepo();
        }
        public void AddUser(User user)
        {
            _userService.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        public void EditUser(User user)
        {
            _userService.EditUser(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        public User GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        public User Authenticate(string email, string password)
        {
            using var db = new LibraryManagementContext();
            var user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                SetLoggedInUser(user);
            }
            return user;
        }

        public User GetLoggedInUser()
        {
            return _loggedInUser;
        }

        public void SetLoggedInUser(User user)
        {
            _loggedInUser = user;
        }
    }
}
