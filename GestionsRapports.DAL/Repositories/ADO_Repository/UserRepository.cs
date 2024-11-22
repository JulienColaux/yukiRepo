using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GestionsRapports.DAL.Entities;
using GestionsRapports.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace GestionsRapports.DAL.Repositories.ADO_Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection  connection;

        // Constructeur pour initialiser la connexion
        public UserRepository(string connectionString)
        {
            connection = new NpgsqlConnection (connectionString);
        }


        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserById(int id)
        {
            var user = connection.QueryFirstOrDefault<User>(
                "SELECT " +
                "id_utilisateur AS User_Id, " +
                "prenom AS Firstname, " +
                "nom AS Lastname, " +
                "mail AS Email, " +
                "numerotelephone AS Phone, " +
                "motdepasse AS Password, " +
                "profil AS Role " +
                "FROM utilisateur WHERE id_utilisateur = @Id", 
                new { id });

            return user;
        }


        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="id">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserByEmail(string email)
        {
            var user = connection.QueryFirstOrDefault<User>(
                "SELECT " +
                "id_utilisateur AS User_Id, " +
                "prenom AS Firstname, " +
                "nom AS Lastname, " +
                "mail AS Email, " +
                "numerotelephone AS Phone, " +
                "motdepasse AS Password, " +
                "profil AS Role " +
                "FROM utilisateur WHERE mail = @email", 
                new { email });

            return user;
        }


        /// <summary>
        /// Checks whether a user exists in the database based on ID.
        /// </summary>
        /// <param name="id">ID to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(int id)
        {
            return 1 <= connection.ExecuteScalar<int>("SELECT COUNT(*) FROM \"utilisateur\" WHERE \"id_utilisateur\" = @Id", new { id });
        }

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="id">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email)
        {
            return 1 <= connection.ExecuteScalar<int>("SELECT COUNT(*) FROM \"utilisateur\" WHERE \"mail\" = @Email", new { email });
        }
    }
}