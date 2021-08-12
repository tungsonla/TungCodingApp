using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TungCodingApp.Core.Services
{
    public interface IUsersService
    {
        List<User> LoadUsers();
        void AddUser(string name, string password);
        bool IsUserNameExists(string name);
    }
}
