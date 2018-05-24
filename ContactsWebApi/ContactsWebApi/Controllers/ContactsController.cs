using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsWebApi.Repositories;
using ContactsWebApi.Models;
using ContactsWebApi.Services;

namespace ContactsWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService; 
        }

        // GET api/contacts
        [HttpGet]
       public IActionResult Get ()
        {
            List<Contact> contacts = _contactService.GetContacts();
            return new JsonResult(contacts);
        }
        // GET api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact contact = _contactService.GetContactById(id);
            return new JsonResult(contact);
        }

        // Post api/contacts

        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            Contact createdContact = _contactService.CreateContact(contact);
            return new JsonResult(createdContact);
            
        }

        // PUT api/contacts/{id}

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Contact contact)
        {
            Contact updatedContact = _contactService.UpdateContact(id, contact);
            return new JsonResult(updatedContact);
            
        }

        // DELETE api/contacts/{id}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Deletecontact(id);
            return new OkResult();
            
        }



    }
}