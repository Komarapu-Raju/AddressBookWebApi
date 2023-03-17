using AddressBookWebApi.DTO.Contacts;
using AddressBookWebApi.Models.Contacts;
using AddressBookWebApi.Services.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebApi.Controllers
{
    [ApiController]
    [Route("ContactController")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;
        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet("GetContactList")]
        public List<ContactDTO> GetContactList()
        {
            return _contactServices.GetContactsList();
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            if (_contactServices.GetContactById(id) == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(_contactServices.GetContactById(id));
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(Contact newContact)
        {
            _contactServices.AddContact(newContact);
            return Ok("Contact added to addressBook");
        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(Contact updatedContact)
        {
            if (_contactServices.GetContactById(updatedContact.Id) != null)
            {
                _contactServices.UpdateContact(updatedContact.Id, updatedContact);
                return Ok("Contact updated successfully");
            }

            return NotFound("Contact not found to update");
        }

        [HttpDelete("DeleteContact/{id}")]
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
