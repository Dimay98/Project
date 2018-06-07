namespace ManagerTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ManagerTest.DAL.Domain;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=ManagerConnection")
        {
        }

        public virtual DbSet<Resourse> Resourses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
