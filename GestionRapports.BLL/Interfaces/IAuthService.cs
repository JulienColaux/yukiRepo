using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRapports.BLL.Models;

namespace GestionRapports.BLL.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Generates a secure JSON Web Token (JWT) for the specified user.
        /// </summary>
        /// <param name="user">The user object containing ID, Email and Password.</param>
        /// <returns>A signed JWT as a string including ID, Email, Expiration date (3 days).</returns>
        public string GenerateToken(User user);
    }
}
