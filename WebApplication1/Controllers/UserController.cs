using System.Collections.Generic;
using System.Web.Http;
using PersonManager.Model.Models;
using PersonManager.Model.Repositories;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> Get()
        {
            return _userRepository.GetUsers();
        }

        //public HttpResponseMessage Post([FromBody]Person person)
        //{
        //    try
        //    {
        //        var maxId = PersonCollection.Persons.Max(x => x.Id);
        //        person.Id = maxId + 1;
        //        PersonCollection.Persons.Add(person);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception exception)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception.Message);
        //    }
        //}

        //public HttpResponseMessage Put(int id,[FromBody]Person person)
        //{
        //    try
        //    {
        //        var oldPerson = PersonCollection.Persons.FirstOrDefault(x => x.Id == id);
        //        if (oldPerson != null)
        //        {
        //            oldPerson.Age = person.Age;
        //            oldPerson.Name = person.Name;

        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Person with Id {person.Id} not found");
        //    }
        //    catch (Exception exception)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception.Message);
        //    }
        //}

        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        var person = PersonCollection.Persons.FirstOrDefault(x => x.Id == id);
        //        if (person != null)
        //        {
        //            PersonCollection.Persons.Remove(person);
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Person with Id {id} not found");
        //    }
        //    catch (Exception exception)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception.Message);
        //    }
        //}
    }
}