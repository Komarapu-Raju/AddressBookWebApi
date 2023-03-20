using AddressBook.Core.Models.Contacts;
using AddressBook.Data.Models.Contacts;
using AutoMapper;

namespace AddressBook.DTO.Profiles
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
