namespace PersonForm
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class User : DbContext
    {
        public User()
            : base("name=User")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.lname)
                .IsUnicode(false);
        }
    }
}
