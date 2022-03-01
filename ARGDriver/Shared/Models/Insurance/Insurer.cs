using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Models.Insurance
{
    public class Insurer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
