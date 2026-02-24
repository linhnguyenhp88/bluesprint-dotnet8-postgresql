using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Shared.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Username { get; set; }
    }
}
 