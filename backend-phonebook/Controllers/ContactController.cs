using backend_phonebook.Context;
using backend_phonebook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDBContext context;
        public ContactController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestor_bd.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.gestor_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Contact contact)
        {
            try
            {
                context.gestor_bd.Add(contact);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = contact.id }, contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/<controller>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Contact contact)
        {
            try
            {
                if (contact.id == id)
                {
                    context.Entry(contact).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = contact.id }, contact);

                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.gestor_bd.FirstOrDefault(g => g.id == id);

                if (gestor != null)
                {
                    context.gestor_bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);

                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }




}
