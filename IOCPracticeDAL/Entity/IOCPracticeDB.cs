namespace IOCPracticeDAL.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public partial class IOCPracticeDB : DbContext
    {
        public IOCPracticeDB()
            : base("name=IOCPracticeDB")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}