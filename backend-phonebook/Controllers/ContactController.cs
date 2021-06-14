using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        List<Contact> Contacts = new List<Contact>()
        {
            new Contact(){Id=1, FirstName="Andres", LastName="Bustamante", Phone=78873788, RegistrationDate="13/06/2021"},
            new Contact(){Id=2, FirstName="William", LastName="Pabon", Phone=65487851, RegistrationDate="14/06/2021"},
            new Contact(){Id=3, FirstName="Grisel", LastName="Quispe", Phone=78956321, RegistrationDate="17/06/2021"}
        };

        [HttpGet]
        public ActionResult<Contact> Get(int Id)
        {
            var contact = Contacts.Where(d => d.Id == Id).FirstOrDefault();
            
            if (contact == null) return NotFound();
            return contact;
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string RegistrationDate { get; set; }
    }


}
