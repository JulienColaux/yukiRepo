using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRapports.BLL.Models;

namespace GestionRapports.BLL.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserById(int id);

        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="id">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserByEmail(string email);

        /// <summary>
        /// Checks whether a user exists in the database based on ID.
        /// </summary>
        /// <param name="id">ID to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(int id);

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="id">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email);
    }
}