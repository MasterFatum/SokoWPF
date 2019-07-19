namespace TeacherSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Technology")]
    public partial class Technology
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int? Evaluation { get; set; }

        public virtual Users Users { get; set; }
    }
}
