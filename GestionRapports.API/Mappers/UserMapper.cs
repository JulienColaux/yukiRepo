using System.Reflection;
using GestionRapports.API.Forms;
using GestionRapports.API.DTOs;
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
                Role = u.Role,
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
        public static Models.User ToModel(this UserLoginForm u)
        {
            return new Models.User
            {
                Email = u.Email,
                Password = u.MotsDePasse
            };
        }
    }
}