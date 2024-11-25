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
        /// Add a new user in the database
        /// </summary>
        /// <param name="user">User to add.</param>
        public User CreateUser(User user);
        
        
        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        public IEnumerable<User> GetAllUsers();
        
        
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
        /// Edit the profil of the user by the ID
        /// </summary>
        /// <param name="id">ID to find the user.</param>
        /// <returns>Update the profil of the user or not.</returns>
        public string editRole(int id, string role);

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="id">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email);

        /// <summary>
        /// Authenticates the specified user and returns a login result containing the user details and a JWT token.
        /// </summary>
        /// <param name="user">The user object containing ID, Email and Password.</param>
        /// <returns>
        /// An object containing JWT token, 
        /// </returns>
        public LoginResult Login(User user);
    }
}