using System.ComponentModel.DataAnnotations;

namespace BountyHuntersAPI.Dtos.Auth
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 25 characters")]
        public string Password { get; set; }
    }
}
