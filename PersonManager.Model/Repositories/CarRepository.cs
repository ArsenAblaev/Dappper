using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PersonManager.Model.Models;

namespace PersonManager.Model.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbConnection _dataBase;

        public CarRepository(IDbConnection dataBase)
        {
            _dataBase = dataBase;
        }
        public List<Car> GetList()
        {
            List<Car> cars;

            using (_dataBase)
            {
                cars = _dataBase.Query<Car>("SELECT * FROM Cars").ToList();
            }
            return cars;
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public Car Create(Car user)
        {
            throw new NotImplementedException();
        }

        public void Update(Car user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
