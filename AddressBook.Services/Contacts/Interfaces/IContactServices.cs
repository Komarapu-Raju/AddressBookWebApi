using AddressBook.Core.Models.Contacts;
using AddressBook.Data.Models.Contacts;

namespace AddressBook.Services.Contacts.Interfaces
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

        void UpdateContact(int id, Contact updatedContact);

        void DeleteContact(int id);

        ContactDTO GetContactById(int id);

        List<ContactDTO> GetContactsList();
    }
}
