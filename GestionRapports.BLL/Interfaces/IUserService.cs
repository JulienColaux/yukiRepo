using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRapports.BLL.Models;

namespace GestionRapports.BLL.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(int id);
        public bool CheckUserExistance(int id);
    }
}