using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Shared.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "You must specify a password between 8 and 20 characters")]
        public string Password { get; set; }
    }
}
