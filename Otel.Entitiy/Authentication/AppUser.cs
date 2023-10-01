
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entity.Authentication
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gsm { get; set; }
        public string? Gender { get; set; }
        public string? TcNO { get; set; }
        public IList<AppRole>? Roles { get; set; }
    }
}
