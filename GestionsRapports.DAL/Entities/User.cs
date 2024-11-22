using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionsRapports.DAL.Entities
{
    public class User
    {
        public int User_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Role Role { get; set; }
    }   
}

public enum Role
{
    EquipeInterne = 1,   
    SuperUtilisateur = 2,    
    Lecteur = 3    
}