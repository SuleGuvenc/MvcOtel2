
using Microsoft.AspNetCore.Identity;
using Otel.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entity.Authentication
{
    public class AppRole : IdentityRole
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
       
    }
}
