using CRUD_application_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_application_2.Services
{
    public class UserControllerService : IUserControllerService
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        public static int UserId = 1;

        public User AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            if (user.Id > 0)
            {
                throw new ArgumentException("Invalid User Id");
            }

            user.Id = UserId++;
            userlist.Add(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            userlist.Remove(user);
            return user;
        }

        public User DeleteUserById(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                DeleteUser(user);
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userlist;
        }

        public User GetUserById(int id)
        {
            return userlist.FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(User existingUser, User updatedUser)
        {
            if (existingUser == null)
            {
                throw new ArgumentNullException(nameof(existingUser), "Existing user cannot be null");
            }

            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser), "Updated user cannot be null");
            }

            int index = userlist.IndexOf(existingUser);
            if (index != -1)
            {
                userlist[index] = updatedUser;
                return userlist[index];
            }

            return null;
        }
    }
}