using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models.Business;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserDBContext db = new UserDBContext();

        // GET api/User
        public List<User> Get()
        {
            return db.Users.ToList();
        }

    }
}
