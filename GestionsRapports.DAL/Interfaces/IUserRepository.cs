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
        public User GetUserById(int id);
        public bool CheckUserExistance(int id);
    }
}