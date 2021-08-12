using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TungCodingApp.Core.Services
{
    public class UsersService : IUsersService
    {
        private static List<User> _storeUsers = new List<User>();

        public List<User> LoadUsers()
        {
            return _storeUsers;
        }

        public void AddUser(string name, string password)
        {
            var newUser = new User() { Name = name, Password = password };
            _storeUsers.Add(newUser);
        }

        public bool IsUserNameExists(string name)
        {
            foreach(User user in _storeUsers)
            {
                if (user.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
