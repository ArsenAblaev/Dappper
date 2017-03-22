using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using PersonManager.Model.Models;

namespace PersonManager.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dataBase;

        public UserRepository(IDbConnection dataBase)
        {
            _dataBase = dataBase;
        }
        public IList<User> GetList()
        {
            List<User> users;

            using (_dataBase)
            {
                users = _dataBase.Query<User>("SELECT * FROM Users").ToList();
                var user = _dataBase.QueryFirst<User>("select * from Users");
            }
            return users;
        }

        public User Get(int id)
        {
            User user;
            using (_dataBase)
            {
                user = _dataBase.QueryFirst<User>("SELECT * FROM Users WHERE Id = @id", new { id });
            }
            return user;
        }

        public User Create(User user)
        {
            using (_dataBase)
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = _dataBase.Query<int>(sqlQuery, user).FirstOrDefault();
                user.Id = (int)userId;
            }
            return user;
        }

        public void Update(User user)
        {
            using (_dataBase)
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                _dataBase.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (_dataBase)
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                _dataBase.Execute(sqlQuery, new { id });
            }
        }

        public void RemoveTop(int count)
        {
            using (_dataBase)
            {
                var sqlQuery = "with cte as (select top @count * from Users) delete from cte";
                _dataBase.Execute(sqlQuery, new { count });
            }
        }
    }
}
