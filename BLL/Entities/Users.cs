namespace BLL.Entities
{
    public class Users
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            //Contests = new HashSet<Contests>();
            //Courses = new HashSet<Courses>();
            //Experience = new HashSet<Experience>();
            //Materials = new HashSet<Materials>();
            //Other = new HashSet<Other>();
            //Publications = new HashSet<Publications>();
            //Technology = new HashSet<Technology>();
            //WorkWithParents = new HashSet<WorkWithParents>();
        }

        public int Id { get; set; }


        public string Lastname { get; set; }


        public string Firstname { get; set; }


        public string Middlename { get; set; }


        public string Position { get; set; }


        public string Privilege { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Contests> Contests { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Courses> Courses { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Experience> Experience { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Materials> Materials { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Other> Other { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Publications> Publications { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Technology> Technology { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<WorkWithParents> WorkWithParents { get; set; }
    }
}
