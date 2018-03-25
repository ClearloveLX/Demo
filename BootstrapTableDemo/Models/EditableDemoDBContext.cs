using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapTableDemo.Models
{
    public class EditableDemoDBContext : DbContext
    {
        public EditableDemoDBContext(DbContextOptions<EditableDemoDBContext> options) : base(options) { }

        public virtual DbSet<InfoEmployee> InfoEmployees { get; set; }
        public virtual DbSet<InfoDepartment> InfoDepartments { get; set; }


        //数据库视图部分
        public virtual DbSet<EmployeeList> EmployeesList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoEmployee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Gender).HasDefaultValueSql("((0))");

                entity.Property(e => e.Department).HasMaxLength(10).IsUnicode(false);

                entity.HasOne(d => d.Departments)
                     .WithMany(p => p.Employees)
                     .HasForeignKey(d => d.Department)
                     .HasConstraintName("FK_InfoEmployee_InfoDepartment");
            });

            modelBuilder.Entity<InfoDepartment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
