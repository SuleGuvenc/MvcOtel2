using Otel.Entitiy.Abstarct;
using Otel.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
    public class Menu :BaseEntity
    {
        public string? AppRoleId { get; set; }
        public AppRole?  AppRole { get; set; }
        public string MenuAdi { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Area { get; set; }
        public string? Class { get; set; }
        public string? Icon { get; set; }
    }
}
