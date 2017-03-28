using System.Collections.Generic;
using System.Threading.Tasks;
using PersonManager.Model.Models;
using PersonManager.Model.Repositories;

namespace PersonManager.Console
{
    public class Client
    {
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;
        public Client(IUserRepository userRepository, ICarRepository carRepository)
        {
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await Task<List<User>>.Factory.StartNew(() => _userRepository.GetList());
            return users;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var cars = await Task<List<Car>>.Factory.StartNew(() => _carRepository.GetList());
            return cars;
        }
    }
}
