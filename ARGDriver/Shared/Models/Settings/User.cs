using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Models.Settings
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public Rol Rol { get; set; }
        public bool Status { get; set; }
    }
}
