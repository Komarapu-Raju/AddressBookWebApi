using AddressBook.Core.Models.Contacts;
using AddressBook.Data.Models.Contacts;
using AddressBook.Services.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebApi.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;
        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet("all")]
        public List<ContactDTO> GetContactList()
        {
            return _contactServices.GetContactsList();
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            if (_contactServices.GetContactById(id) == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(_contactServices.GetContactById(id));
        }

        [HttpPost("add")]
        public IActionResult AddContact(Contact newContact)
        {
            _contactServices.AddContact(newContact);
            return Ok("Contact added to addressBook");
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateContact(int id, Contact updatedContact)
        {
            if (_contactServices.GetContactById(id) != null)
            {
                _contactServices.UpdateContact(id, updatedContact);
                return Ok("Contact updated successfully");
            }

            return NotFound("Contact not found to update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (_contactServices.GetContactById(id) != null)
            {
                _contactServices.DeleteContact(id);
                return Ok("Contact deleted successfully");
            }

            return NotFound("Contact not found");
        }
    }
}
