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

namespace VLaboralApi.Models
{
    public class SubRubrosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/SubRubros
        public IQueryable<SubRubro> GetSubRubros()
        {
            return db.SubRubros;
        }

        // GET: api/SubRubros/5
        [ResponseType(typeof(SubRubro))]
        public IHttpActionResult GetSubRubro(int id)
        {
            SubRubro subRubro = db.SubRubros.Find(id);
            if (subRubro == null)
            {
                return NotFound();
            }

            return Ok(subRubro);
        }

        // PUT: api/SubRubros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubRubro(int id, SubRubro subRubro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subRubro.Id)
            {
                return BadRequest();
            }

            db.Entry(subRubro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubRubroExists(id))
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

        // POST: api/SubRubros
        [ResponseType(typeof(SubRubro))]
        public IHttpActionResult PostSubRubro(SubRubro subRubro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubRubros.Add(subRubro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subRubro.Id }, subRubro);
        }

        // DELETE: api/SubRubros/5
        [ResponseType(typeof(SubRubro))]
        public IHttpActionResult DeleteSubRubro(int id)
        {
            SubRubro subRubro = db.SubRubros.Find(id);
            if (subRubro == null)
            {
                return NotFound();
            }

            db.SubRubros.Remove(subRubro);
            db.SaveChanges();

            return Ok(subRubro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubRubroExists(int id)
        {
            return db.SubRubros.Count(e => e.Id == id) > 0;
        }
    }
}