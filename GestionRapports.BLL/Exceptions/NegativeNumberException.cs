﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRapports.BLL.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() { }
        public NegativeNumberException(string message) : base (message) { }
    }
}