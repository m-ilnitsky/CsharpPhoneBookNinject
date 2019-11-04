using System.Data.Entity;

using CsharpPhoneBookEF.Model.Entities;

namespace CsharpPhoneBookEF.Model.Context
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookContext() : base("IlnitskyPhoneBookConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PhoneBookContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(c => c.Family).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(c => c.Phone).IsRequired().HasMaxLength(12);

            base.OnModelCreating(modelBuilder);
        }
    }
}