using System.ComponentModel.DataAnnotations;

namespace GestionRapports.API.Forms;

public class editRoleForm
{
    /// <summary>
    /// Profil sélectionné pour l'utilisateur, doit correspondre à une valeur valide de l'énumération Profil.
    /// </summary>
    [Required(ErrorMessage = "Le champ 'Profil' est obligatoire.")]
    public Profil Profil { get; set; }

    /// <summary>
    /// Identifiant de l'utilisateur à mettre à jour.
    /// </summary>
    [Required(ErrorMessage = "Le champ 'UserId' est obligatoire.")]
    public int UserId { get; set; }
}
