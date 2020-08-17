using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList
{
    public class ContactListContext : DbContext
    {
        public ContactListContext (DbContextOptions<ContactListContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        { 
            builder.Entity<Contact>().HasIndex(u => u.Number).IsUnique();
            builder.Entity<Contact>().Property(n => n.Name).IsRequired();
            builder.Entity<Contact>().Property(c => c.Surname).IsRequired();
        }
    }
}
