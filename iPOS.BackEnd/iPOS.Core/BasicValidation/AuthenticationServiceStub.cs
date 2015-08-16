using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Core.BasicValidation
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Validates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool Validate(string username, string password);
    }

    public class AuthenticationServiceStub : IAuthenticationService
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticationServiceStub(string username, string password)
        {
            Password = password;
            Username = username;
        }

        public bool Validate(string username, string password)
        {
            return username == Username && password == Password;
        }
    }
}
