using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Entities
{
    public class User
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string Privilege { get; set; }
    }
}
