using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using PersonManager.Model.Repositories;

namespace PersonManager.Console
{
    class Program
    {
        private static Client _client;

        static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dbConnection = new SqlConnection(connectionString);
            var dbConnection2 = new SqlConnection(connectionString);

            _client = new Client(new UserRepository(dbConnection), new CarRepository(dbConnection2));

            GetUsers();
            GetCars();

            System.Console.ReadLine();

        }

        private static async void GetUsers()
        {
            var users = await _client.GetUsersAsync();

            foreach (var user in users)
            {
                System.Console.WriteLine($"{user.Name}, Thread:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
            }
        }

        private static async void GetCars()
        {
            var cars = await _client.GetCarsAsync();

            foreach (var car in cars)
            {
                System.Console.WriteLine($"{car.Model}, Thread:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
            }
        }

    }
}
