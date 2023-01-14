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
    public class totexpsController : ApiController
    {
        private ExpDBEntities db = new ExpDBEntities();

        // GET: api/totexps
        public IQueryable<totexp> Gettotexps()
        {
            return db.totexps;
        }

        // GET: api/totexps/5
        [ResponseType(typeof(totexp))]
        public IHttpActionResult Gettotexp(int id)
        {
            totexp totexp = db.totexps.Find(id);
            if (totexp == null)
            {
                return NotFound();
            }

            return Ok(totexp);
        }

        // PUT: api/totexps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttotexp(int id, totexp totexp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != totexp.id)
            {
                return BadRequest();
            }

            db.Entry(totexp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!totexpExists(id))
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

        // POST: api/totexps
        [ResponseType(typeof(totexp))]
        public IHttpActionResult Posttotexp(totexp totexp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.totexps.Add(totexp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = totexp.id }, totexp);
        }

        // DELETE: api/totexps/5
        [ResponseType(typeof(totexp))]
        public IHttpActionResult Deletetotexp(int id)
        {
            totexp totexp = db.totexps.Find(id);
            if (totexp == null)
            {
                return NotFound();
            }

            db.totexps.Remove(totexp);
            db.SaveChanges();

            return Ok(totexp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool totexpExists(int id)
        {
            return db.totexps.Count(e => e.id == id) > 0;
        }
    }
}