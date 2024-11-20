using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRapports.BLL.Interfaces;
using GestionRapports.BLL.Mappers;
using GestionRapports.BLL.Models;
using GestionsRapports.DAL.Interfaces;

namespace GestionRapports.BLL.Services
{
    public class UserService(IUserRepository repo) : IUserService
    {
        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
    public User GetUserById(int id)
    {
        return repo.GetUserById(id).ToModel();
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
}
}