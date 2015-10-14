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
using VLaboralApi.Models;

namespace VLaboralApi.Controllers
{
    public class PuestosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Puestos
        public IQueryable<Puesto> GetPuestoes()
        {
            return db.Puestos;
        }

        // GET: api/Puestos/5
        [ResponseType(typeof(Puesto))]
        public IHttpActionResult GetPuesto(int id)
        {
            Puesto puesto = db.Puestos.Find(id);
            if (puesto == null)
            {
                return NotFound();
            }

            return Ok(puesto);
        }

        // PUT: api/Puestos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPuesto(int id, Puesto puesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puesto.Id)
            {
                return BadRequest();
            }

            db.Entry(puesto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puestos
        [ResponseType(typeof(Puesto))]
        public IHttpActionResult PostPuesto(Puesto puesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Puestos.Add(puesto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = puesto.Id }, puesto);
        }

        // DELETE: api/Puestos/5
        [ResponseType(typeof(Puesto))]
        public IHttpActionResult DeletePuesto(int id)
        {
            Puesto puesto = db.Puestos.Find(id);
            if (puesto == null)
            {
                return NotFound();
            }

            db.Puestos.Remove(puesto);
            db.SaveChanges();

            return Ok(puesto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuestoExists(int id)
        {
            return db.Puestos.Count(e => e.Id == id) > 0;
        }
    }
}