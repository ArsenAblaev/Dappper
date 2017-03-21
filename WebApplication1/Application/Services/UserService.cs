using System.Collections.Generic;
using PersonManager.Model.Models;
using PersonManager.Model.Repositories;

namespace WebApplication1.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<User> GetUsers()
        {
            return _userRepository.GetList();
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(userId);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public User Add(User user)
        {
            return _userRepository.Create(user);
        }
    }
}