using BLL.Entities;
using System.Data.Entity;

namespace BLL
{
    

    public class SokoContext : DbContext
    {
        public SokoContext()
            : base("name=Soko")
        {
        }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
