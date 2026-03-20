using System.ComponentModel.DataAnnotations;

namespace GC_Board_Game_Cats.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
