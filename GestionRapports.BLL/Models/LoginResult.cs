﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRapports.BLL.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
