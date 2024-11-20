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
    public string Email { get; set; } = string.Empty;
    public string MotsDePasse { get; set; } = string.Empty;
    }   
}