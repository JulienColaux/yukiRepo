using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GestionsRapports.DAL.Entities;
using GestionsRapports.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace GestionsRapports.DAL.Repositories.ADO_Repository
{
    public class UserRepository(SqlConnection connection) : IUserRepository
    {

        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserById(int id)
        {
            return connection.QueryFirst<User>("SELECT * FROM [dbo].[Users] WHERE User_Id = @Id", new { id });
        }

        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="id">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserByEmail(string email)
        {
            return connection.QueryFirst<User>("SELECT * FROM [dbo].[Users] WHERE Email = @Email", new { email });
        }


        /// <summary>
        /// Checks whether a user exists in the database based on ID.
        /// </summary>
        /// <param name="id">ID to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(int id)
        {
            return 1 <= connection.ExecuteScalar<int>("SELECT COUNT(*) FROM [dbo].[Users] WHERE User_Id = @Id", new { id });
        }

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="id">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email)
        {
            return 1 <= connection.ExecuteScalar<int>("SELECT COUNT(*) FROM [dbo].[Users] WHERE Email = @Email", new { email });
        }
    }
}