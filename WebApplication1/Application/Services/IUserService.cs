using System.Collections.Generic;
using PersonManager.Model.Models;

namespace WebApplication1.Application.Services
{
    public interface IUserService
    {
        IList<User> GetUsers();
        User GetUser(int userId);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        User Add(User user);
    }
}