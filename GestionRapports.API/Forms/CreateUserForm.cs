using System.ComponentModel.DataAnnotations;

namespace GestionRapports.API.Forms;

public class CreateUserForm
{
    /// <summary>
    /// Le prénom de l'utilisateur.
    /// </summary>
    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
    public string Firstname { get; set; }

    /// <summary>
    /// Le nom de famille de l'utilisateur.
    /// </summary>
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
    public string Lastname { get; set; }

    /// <summary>
    /// L'adresse email de l'utilisateur.
    /// </summary>
    [Required(ErrorMessage = "L'email est obligatoire.")]
    [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
    public string Email { get; set; }

    /// <summary>
    /// Le numéro de téléphone de l'utilisateur.
    /// </summary>
    [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
    public string Phone { get; set; }

    /// <summary>
    /// Le mot de passe de l'utilisateur.
    /// </summary>
    [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Le mot de passe doit comporter entre 8 et 100 caractères.")]
    public string Password { get; set; }

    /// <summary>
    /// Le rôle de l'utilisateur.
    /// </summary>
    [Required(ErrorMessage = "Le rôle est obligatoire.")]
    public Profil Profil { get; set; }
}
