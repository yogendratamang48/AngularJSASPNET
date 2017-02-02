using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonInfoesController : ApiController
    {
        private PersonEntities db = new PersonEntities();

        // GET: api/PersonInfoes
        public IQueryable<PersonInfo> GetPersonInfoes()
        {
            return db.PersonInfoes;
        }

        // GET: api/PersonInfoes/5
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult GetPersonInfo(int id)
        {
            PersonInfo personInfo = db.PersonInfoes.Find(id);
            if (personInfo == null)
            {
                return NotFound();
            }

            return Ok(personInfo);
        }

        // PUT: api/PersonInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonInfo(int id, PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personInfo.PersonID)
            {
                return BadRequest();
            }

            db.Entry(personInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonInfoes
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult PostPersonInfo(PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonInfoes.Add(personInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personInfo.PersonID }, personInfo);
        }

        // DELETE: api/PersonInfoes/5
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult DeletePersonInfo(int id)
        {
            PersonInfo personInfo = db.PersonInfoes.Find(id);
            if (personInfo == null)
            {
                return NotFound();
            }

            db.PersonInfoes.Remove(personInfo);
            db.SaveChanges();

            return Ok(personInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonInfoExists(int id)
        {
            return db.PersonInfoes.Count(e => e.PersonID == id) > 0;
        }
    }
}