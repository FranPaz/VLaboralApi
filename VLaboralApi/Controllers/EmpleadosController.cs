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
    public class EmpleadosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Empleados
        [Authorize]
        public IHttpActionResult GetEmpleados()
        {
            try
            {
                var listEmpleados = db.Empleados.ToList();
                if (listEmpleados == null)
                {
                    return BadRequest("No existen empleados cargados");
                }
                return Ok(listEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id, int prmDni)
        {
            var empleadoExistente = (from e in db.Empleados
                                       where e.Dni == prmDni
                                       select e).FirstOrDefault();


            if (empleadoExistente == null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Ya existe un empleado cargado con el mismo dni");
            }

        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.Id)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleados
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var empleadosExistentes = (from e in db.Empleados
                                       where e.Dni == empleado.Dni
                                       select e).FirstOrDefault();               
                

            if (empleadosExistentes == null)
            {
                try
                {
                    db.Empleados.Add(empleado);
                    db.SaveChanges();

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }
            }
            else
            {
                return BadRequest("Ya existe un empleado cargado con el mismo dni");
            }
            
            
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleados.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.Empleados.Count(e => e.Id == id) > 0;
        }
    }
}