namespace TeacherSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class SokoContext : DbContext
    {
        public SokoContext()
            : base("name=Soko")
        {
        }

        public virtual DbSet<Contests> Contests { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Other> Other { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkWithParents> WorkWithParents { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Contests)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Courses)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Experience)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Materials)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Other)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Publications)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Technology)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.WorkWithParents)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserId)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
