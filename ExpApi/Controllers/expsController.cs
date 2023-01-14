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
    public class expsController : ApiController
    {
        private ExpDBEntities db = new ExpDBEntities();

        // GET: api/exps
        public IQueryable<exp> Getexps()
        {
            return db.exps;
        }

        // GET: api/exps/5
        [ResponseType(typeof(exp))]
        public IHttpActionResult Getexp(int id)
        {
            exp exp = db.exps.Find(id);
            if (exp == null)
            {
                return NotFound();
            }

            return Ok(exp);
        }

        // PUT: api/exps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putexp(int id, exp exp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exp.id)
            {
                return BadRequest();
            }

            db.Entry(exp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!expExists(id))
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

        // POST: api/exps
        [ResponseType(typeof(exp))]
        public IHttpActionResult Postexp(exp exp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.exps.Add(exp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exp.id }, exp);
        }

        // DELETE: api/exps/5
        [ResponseType(typeof(exp))]
        public IHttpActionResult Deleteexp(int id)
        {
            exp exp = db.exps.Find(id);
            if (exp == null)
            {
                return NotFound();
            }

            db.exps.Remove(exp);
            db.SaveChanges();

            return Ok(exp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool expExists(int id)
        {
            return db.exps.Count(e => e.id == id) > 0;
        }
    }
}