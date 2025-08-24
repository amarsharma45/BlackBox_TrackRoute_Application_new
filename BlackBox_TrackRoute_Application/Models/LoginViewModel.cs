using System.ComponentModel.DataAnnotations;

namespace BlackBox_TrackRoute_Application.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(10)]
        public string Username { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
