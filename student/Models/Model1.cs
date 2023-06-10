using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace student.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_student> tbl_student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_student>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_student>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_student>()
                .Property(e => e.Semester)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_student>()
                .Property(e => e.Fees)
                .IsUnicode(false);
        }
    }
}
