using System.ComponentModel.DataAnnotations;

namespace GestionRapports.API.Forms
{
    public class UserLoginForm
    {
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required][MaxLength(50)] public string MotsDePasse { get; set; } = string.Empty;
    }
}
