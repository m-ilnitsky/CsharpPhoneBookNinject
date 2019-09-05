using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CsharpPhoneBookEF.Models
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookContext() : base("IlnitskyPhoneBookConnection")
        {
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