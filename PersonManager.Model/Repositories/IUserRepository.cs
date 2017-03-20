using System.Collections.Generic;
using PersonManager.Model.Models;

namespace PersonManager.Model.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User Get(int id);
        User Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
