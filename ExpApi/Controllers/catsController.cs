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
using ExpApi.Models;
using EntityState = System.Data.Entity.EntityState;

namespace ExpApi.Controllers
{
    public class catsController : ApiController
    {
        private ExpDBEntities db = new ExpDBEntities();

        // GET: api/cats
        public IQueryable<cat> Getcats()
        {
            return db.cats;
        }

        // GET: api/cats/5
        [ResponseType(typeof(cat))]
        public IHttpActionResult Getcat(int id)
        {
            cat cat = db.cats.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        // PUT: api/cats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcat(int id, cat cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat.id)
            {
                return BadRequest();
            }

            db.Entry(cat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!catExists(id))
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

        // POST: api/cats
        [ResponseType(typeof(cat))]
        public IHttpActionResult Postcat(cat cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cats.Add(cat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cat.id }, cat);
        }

        // DELETE: api/cats/5
        [ResponseType(typeof(cat))]
        public IHttpActionResult Deletecat(int id)
        {
            cat cat = db.cats.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            db.cats.Remove(cat);
            db.SaveChanges();

            return Ok(cat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool catExists(int id)
        {
            return db.cats.Count(e => e.id == id) > 0;
        }
    }
}