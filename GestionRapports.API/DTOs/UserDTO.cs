namespace GestionRapports.API.DTOs
{
    public class UserDTO
    {
        public int User_Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string MotsDePasse { get; set; } = string.Empty;
    }
}