using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionsRapports.DAL.Entities;

namespace GestionsRapports.DAL.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add a new user in the database
        /// </summary>
        /// <param name="user">User to add.</param>
        public User CreateUser(User user, string roleValue);
        
        
        
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
        /// Retrieves a user from the database by Email.
        /// </summary>
        public IEnumerable<User> GetUsers();
        
        /// <summary>
        /// Edit the profil of the user by the ID
        /// </summary>
        /// <param name="id">ID to find the user.</param>
        /// <returns>Update the profil of the user or not.</returns>
        public string editRole(int id, string roleValue);
        
        

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