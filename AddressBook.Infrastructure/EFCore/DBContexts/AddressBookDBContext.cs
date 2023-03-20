using AddressBook.Data.Models.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.EFCore.DBContexts
{
    public class AddressBookDBContext : DbContext
    {
        public AddressBookDBContext(DbContextOptions<AddressBookDBContext> options) : base(options)
        {
        }

        public DbSet<Contact> ContactTable { get; set; }
    }
}
