using AddressBookWebApi.DTO.Contacts;
using AddressBookWebApi.Infrastructure.EFCore.DBContexts;
using AddressBookWebApi.Models.Contacts;
using AddressBookWebApi.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBookWebApi.Services.Contacts.Services
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
            var existingContact = _db.ContactTable.Find(id);

            if (existingContact != null)
            {
                _db.Entry(existingContact).State = EntityState.Detached;
            }

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
