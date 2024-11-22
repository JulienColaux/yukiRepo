using System.Reflection;
using GestionRapports.API.Forms;
using GestionRapports.API.DTOs;
using GestionsRapports.DAL.Entities;
using Models = GestionRapports.BLL.Models;

namespace GestionRapports.API.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(this Models.User u)
        {
            return new UserDTO
            {
                User_Id = u.User_Id,
                Email = u.Email,
                Password = u.Password,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Profil = u.Profil,
                Phone = u.Phone,
                
            };
        }
        
        public static UserCreateDTO ToDTO(this CreateUserForm u)
        {
            return new UserCreateDTO
            {
                Email = u.Email,
                Password = u.Password,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Profil = u.Profil,
                Phone = u.Phone,
            };
        }
        
        public static Models.User ToModel(this CreateUserForm u)
        {
            return new Models.User
            {
                Email = u.Email,
                Password = u.Password,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Profil = u.Profil,
                Phone = u.Phone,
            };
        }
        
        
        
        public static Models.User Tomodels(this UserForm u)
        {
            return new Models.User
            {
                Email = u.Email,
                Password = u.MotsDePasse
            };
        }
    }
}