using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRapports.BLL.Exceptions
{
    public class CredentialException : Exception
    {
        public CredentialException() { }
        public CredentialException(string message) : base(message) { }
    }
}
