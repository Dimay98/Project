namespace ManagerTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ManagerTest.DAL.Domain;

    public partial class ResourseContext : DbContext
    {
        public ResourseContext()
            : base("name=ManagerConnection")
        {
        }

        public virtual DbSet<Resourse> Resourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
