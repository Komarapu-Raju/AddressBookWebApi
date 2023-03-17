using AddressBookWebApi.DTO.Contacts;
using AddressBookWebApi.Models.Contacts;

namespace AddressBookWebApi.Services.Contacts.Interfaces
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
