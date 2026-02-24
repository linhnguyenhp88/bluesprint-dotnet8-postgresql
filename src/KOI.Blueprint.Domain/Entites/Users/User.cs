using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Domain.Entites.Users
{
    [Table("users")]
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public string Status { get; set; }
    }
}
