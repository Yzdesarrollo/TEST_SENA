using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Helpers
{
    public class UserTime
    {
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public int? UserDelete { get; set; }

        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
