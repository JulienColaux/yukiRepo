using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = GestionsRapports.DAL.Entities;
using Models = GestionRapports.BLL.Models;

namespace GestionRapports.BLL.Mappers
{
    public static class UserMapper
    {
        public static Models.User ToModel(this Entities.User u)
        {
            return new Models.User
            {
                User_Id = u.User_Id,
                Email = u.Email,
                MotsDePasse = u.MotsDePasse
            };
        }
        public static Entities.User ToEntity(this Models.User u)
        {
            return new Entities.User
            {
                User_Id = u.User_Id,
                Email = u.Email,
                MotsDePasse = u.MotsDePasse
            };
        }
    }
}