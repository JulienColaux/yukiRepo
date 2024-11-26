using System;
using System.Collections.Generic;
using System.Data.Common;
using Dapper;
using GestionsRapports.DAL.Entities;
using GestionsRapports.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace GestionsRapports.DAL.Repositories.ADO_Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection  _connection;

        // Constructeur pour initialiser la connexion par injection de dépendance
        public UserRepository(string connectionString)
        {
            _connection = new NpgsqlConnection (connectionString);
        }

        // Mapper de User 
        public static User Mapper(User user)
        {
            return new User
            {
                User_Id = user.User_Id,
                Firstname = user.Firstname,  
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Profil = user.Profil 
            };
        }

        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserById(int id)
        {
            var user = _connection.QueryFirstOrDefault<User>(
                "SELECT " +
                "id_utilisateur AS User_Id, " +
                "prenom AS Firstname, " +
                "nom AS Lastname, " +
                "mail AS Email, " +
                "numerotelephone AS Phone, " +
                "motdepasse AS Password, " +
                "profil AS Profil " +
                "FROM utilisateur WHERE id_utilisateur = @Id", 
                new { id });

            return user;
        }


        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="email">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserByEmail(string email)
        {
            var user = _connection.QueryFirstOrDefault<User>(
                "SELECT " +
                "id_utilisateur AS User_Id, " +
                "prenom AS Firstname, " +
                "nom AS Lastname, " +
                "mail AS Email, " +
                "numerotelephone AS Phone, " +
                "motdepasse AS Password, " +
                "profil AS Profil " +
                "FROM utilisateur WHERE mail = @email", 
                new { email });

            return user;
        }

        /// <summary>
        /// Edit the profil of the user by the ID
        /// </summary>
        /// <param name="id">ID to find the user.</param>
        /// <returns>Update the profil of the user or not.</returns>
        public string editRole(int id, string roleValue)
        {
            try
            {
                var sql = "UPDATE utilisateur SET profil = @roleValue WHERE id_utilisateur = @id";

                _connection.Execute(sql, new { id = id, roleValue = roleValue });

                return roleValue;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
            
         /// </summary>  
        /// Retrieves a user from the database by Email.
        /// </summary>
        public IEnumerable<User> GetUsers()
        {
            var sql = "SELECT " +
                "id_utilisateur AS User_Id, " +
                "prenom AS Firstname, " +
                "nom AS Lastname, " +
                "mail AS Email, " +
                "numerotelephone AS Phone, " +
                "motdepasse AS Password, " +
                "profil AS Profil " + 
                "FROM utilisateur";
            
            return _connection.Query<User>(sql);

        }


        public User CreateUser(User user, string profil)
        {
            var sql = "INSERT INTO utilisateur (prenom, nom, mail, numerotelephone, motdepasse, profil)" +
                          "VALUES (@Firstname, @Lastname, @Email, @Phone, @Password, @Profil) " +
                          "RETURNING "+
                        "id_utilisateur AS User_Id, " +
                        "prenom AS Firstname, " +
                        "nom AS Lastname, " +
                        "mail AS Email, " +
                        "numerotelephone AS Phone, " +
                        "motdepasse AS Password, " +
                        "profil AS Profil ";
            
            return _connection.QueryFirstOrDefault<User>(sql, new
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Profil = profil 
            });
        }
        

        /// <summary>
        /// Checks whether a user exists in the database based on ID.
        /// </summary>
        /// <param name="id">ID to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(int id)
        {
            return 1 <= _connection.ExecuteScalar<int>("SELECT COUNT(*) FROM utilisateur WHERE id_utilisateur = @Id", new { id });
        }

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="email">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email)
        {
            return 1 <= _connection.ExecuteScalar<int>("SELECT COUNT(*) FROM utilisateur WHERE mail = @Email", new { email });
        }
    }
}
