using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRapports.BLL.Exceptions;
using GestionRapports.BLL.Interfaces;
using GestionRapports.BLL.Mappers;
using GestionRapports.BLL.Models;
using GestionsRapports.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;

namespace GestionRapports.BLL.Services
{
    public class UserService(IUserRepository repo, IAuthService authService) : IUserService
    {
        
        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        public IEnumerable<User> GetAllUsers()
        {
            return repo.GetUsers().Select(u => u.ToModel());
        }

        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserById(int id)
        {
            return repo.GetUserById(id).ToModel();
        }

        public User CreateUser(User user)
        {
            if (user == null | string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                new Exception("Email or password is incorrect.");
            }

            if (repo.CheckUserExistance(user.Email))
            {
                new Exception("Email already exists.");
            }
            
            string passwordHash = Argon2.Hash(user.Password);
            user.Password = passwordHash;
            
            Console.WriteLine(user.Profil.ToString());

            string Profil = user.Profil.ToString(); 
    
            GestionsRapports.DAL.Entities.User userEntity = repo.CreateUser(user.ToEntity(), Profil);
            
            return userEntity.ToModel();
        }

        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="id">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public User GetUserByEmail(string email)
        {
            return repo.GetUserByEmail(email).ToModel();
        }

        /// <summary>
        /// Checks whether a user exists in the database based on ID.
        /// </summary>
        /// <param name="id">ID to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(int id)
        {
            return repo.CheckUserExistance(id);
        }

        /// <summary>
        /// Edit the profil of the user by the ID
        /// </summary>
        /// <param name="id">ID to find the user.</param>
        /// <returns>Update the profil of the user or not.</returns>
        public string editRole(int id, string role)
        {
            if (repo.GetUserById(id) == null)
            {
                new Exception("User not found.");
            }

            GestionsRapports.DAL.Entities.User userEntity = repo.GetUserById(id);
            
            
            repo.editRole(id, role);

            return role;
        }

        /// <summary>
        /// Checks whether a user exists in the database based on Email.
        /// </summary>
        /// <param name="id">Email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool CheckUserExistance(string email)
        {
            return repo.CheckUserExistance(email);
        }

        /// <summary>
        /// Authenticates the specified user and returns a login result containing the user details and a JWT token.
        /// </summary>
        /// <param name="user">The user object containing ID, Email and Password.</param>
        /// <returns>
        /// An object containing JWT token, 
        /// </returns>
        public LoginResult Login(User user)
        {
            User? foundUser = repo.GetUserByEmail(user.Email)?.ToModel();

            if (foundUser != null && foundUser.Password != null && Argon2.Verify(foundUser.Password, user.Password))
            {
                string token = authService.GenerateToken(foundUser);

                return new LoginResult
                {
                    Token = token,
                    User = foundUser
                };
            }

            throw new CredentialException("E-mail ou mot de passe incorrect.");
        }
    }
}