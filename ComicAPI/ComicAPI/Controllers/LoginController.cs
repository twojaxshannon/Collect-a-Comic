using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicAPI.Models;
using ComicAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginService _loginService = new LoginService();

        /// <summary>
        /// Demo login method. Attempt to log into the site as the given user.
        /// </summary>
        /// <param name="userName">Name of the user to log in as.</param>
        /// <returns></returns>
        // GET api/login/name
        [HttpGet("{userName}")]
        public ActionResult<User> Get(string userName)
        {
            return _loginService.Login(userName);
        }
    }
}