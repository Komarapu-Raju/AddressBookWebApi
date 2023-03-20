using AddressBook.Core.Models.Contacts;
using AddressBook.Data.Models.Contacts;
using AddressBook.Services.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Api.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;
        public ContactController(IContactServices contactServices)
        {
            this._contactServices = contactServices;
        }

        [HttpGet("all")]
        public List<ContactDTO> GetContactList()
        {
            return this._contactServices.GetContactsList();
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            if (this._contactServices.GetContactById(id) == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(this._contactServices.GetContactById(id));
        }

        [HttpPost("add")]
        public IActionResult AddContact(Contact newContact)
        {
            this._contactServices.AddContact(newContact);
            return Ok("Contact added to addressBook");
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateContact(int id, Contact updatedContact)
        {
            if (this._contactServices.GetContactById(id) != null)
            {
                this._contactServices.UpdateContact(id, updatedContact);
                return Ok("Contact updated successfully");
            }

            return NotFound("Contact not found to update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (this._contactServices.GetContactById(id) != null)
            {
                this._contactServices.DeleteContact(id);
                return Ok("Contact deleted successfully");
            }

            return NotFound("Contact not found");
        }
    }
}
