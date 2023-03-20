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
            _db = db;
        }

        public void AddContact(Contact newContact)
        {
            _db.ContactTable.Add(newContact);
            _db.SaveChanges();
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            Contact existingContact = _db.ContactTable.Find(id);
            _db.ContactTable.Entry(existingContact).State = EntityState.Detached;
            _db.ContactTable.Update(updatedContact);
            _db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var obj = _db.ContactTable.Find(id);
            _db.ContactTable.Remove(obj);
            _db.SaveChanges();
        }

        public ContactDTO GetContactById(int id)
        {
            return mapper.Map<ContactDTO>(_db.ContactTable.Find(id));
        }

        public List<ContactDTO> GetContactsList()
        {
            return mapper.Map<List<ContactDTO>>(_db.ContactTable.ToList());
        }
    }
}
