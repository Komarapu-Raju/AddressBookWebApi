using AddressBook.Infrastructure.EFCore.DBContexts;
using AddressBook.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AddressBook.Core.Models.Contacts;
using AddressBook.Data.Models.Contacts;

namespace AddressBook.Services.Contacts.Services
{
    public class ContactServices : IContactServices
    {
        private readonly AddressBookDBContext _db;

        private readonly IMapper mapper;

        public ContactServices(AddressBookDBContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this._db = db;
        }

        public void AddContact(Contact newContact)
        {
            this._db.ContactTable.Add(newContact);
            this._db.SaveChanges();
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            Contact existingContact = this._db.ContactTable.Find(id);
            this._db.ContactTable.Entry(existingContact).State = EntityState.Detached;
            this._db.ContactTable.Update(updatedContact);
            this._db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var obj = this._db.ContactTable.Find(id);
            this._db.ContactTable.Remove(obj);
            this._db.SaveChanges();
        }

        public ContactDTO GetContactById(int id)
        {
            return this.mapper.Map<ContactDTO>(this._db.ContactTable.Find(id));
        }

        public List<ContactDTO> GetContactsList()
        {
            return this.mapper.Map<List<ContactDTO>>(this._db.ContactTable.ToList());
        }
    }
}
