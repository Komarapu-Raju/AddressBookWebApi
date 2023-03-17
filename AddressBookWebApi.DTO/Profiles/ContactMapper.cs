using AddressBookWebApi.DTO.Contacts;
using AddressBookWebApi.Models.Contacts;
using AutoMapper;

namespace AddressBookWebApi.DTO.Profiles
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
