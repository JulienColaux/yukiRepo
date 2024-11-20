using System.Reflection;
using GestionRapports.API.Forms;
using DTO = GestionRapports.API.DTOs;
using Models = GestionRapports.BLL.Models;

namespace GestionRapports.API.Mappers
{
    public static class UserMapper
    {
        public static DTO.UserDTO ToDTO(this Models.User u)
        {
            return new DTO.UserDTO
            {
                User_Id = u.User_Id,
                Email = u.Email,
                MotsDePasse = u.MotsDePasse
                
            };
        }
        public static Models.User Tomodels(this UserForm u)
        {
            return new Models.User
            {
                Email = u.Email,
                MotsDePasse = u.MotsDePasse
            };
        }
    }
}