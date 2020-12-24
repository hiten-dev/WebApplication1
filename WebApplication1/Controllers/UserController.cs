using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            User a = new User()
            {
                ID = 1,
                Name = "John",
                Address = "NYC",
                Role = "Admin"
            };
            users.Add(a);
            return users.ToArray();

            //return Enumerable.Range(1, 1).Select(index => new User
            //{
            //    ID = 1,
            //    Name = "John",
            //    Address = "NYC",
            //    Role = "Admin"
            //})
            //.ToArray();
        }
    }
}
