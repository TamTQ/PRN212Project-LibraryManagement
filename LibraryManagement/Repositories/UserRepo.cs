using LibraryManagement.BusinessObject;
using LibraryManagement.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class UserRepo : IUserRepo
    {
        public void AddUser(User user) => UserDAO.AddUser(user);

        public void DeleteUser(int id) => UserDAO.DeleteUser(id);

        public void EditUser(User user) => UserDAO.EditUser(user);

        public User GetUserByEmail(string email) => UserDAO.GetUserByEmail(email);

        public User GetUserById(int id) => UserDAO.GetUserById(id);

        public List<User> GetUsers() => UserDAO.GetUsers();
    }
}
