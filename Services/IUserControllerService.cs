using CRUD_application_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_application_2.Services
{
    public interface IUserControllerService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User AddUser(User user);
        User UpdateUser(User existingUser, User updatedUser);
        User DeleteUserById(int userId);
        User DeleteUser(User user);
    }
}