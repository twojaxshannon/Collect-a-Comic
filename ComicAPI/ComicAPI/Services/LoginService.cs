using ComicAPI.DAL.Repositories;
using ComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Services
{
    public class LoginService
    {
        UserRepository _userRepository;

        /// <summary>
        /// Initialize with default values.
        /// </summary>
        public LoginService()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Enable a pseudo-login system by fetching the User with the given name.
        /// NOT SECURE - DEMO ONLY.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User Login(string userName)
        {
            // NOTE: Skipping validation, authentication, and all other security goodness - just a demo!
            User user = _userRepository.GetUserByName(userName);

            if (user == null)
            {
                // Ohs nos, this person doesn't exist...

                //... But this is a demo project, so let's pretend they do.
                user = new User() { Name = userName };
                user.Name = userName;
                _userRepository.Save(user); // Tada, the user exists now!
            }

            return user;
        }
    }
}
