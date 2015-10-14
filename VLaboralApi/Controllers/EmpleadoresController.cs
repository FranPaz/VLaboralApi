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
using VlaboralApi.Infrastructure;
using VLaboralApi.Models;

namespace VLaboralApi.Controllers
{
    public class EmpleadoresController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Empleadores
        public IHttpActionResult GetEmpleadores()
        {   
            try
            {
                var listEmpleadores = db.Empleadores.ToList();
                if (listEmpleadores == null)
                {
                    return BadRequest("No existen empleadores cargados");
                }

                var listSubrubros = new List<SubRubro>();
                var subrubro1 = db.SubRubros.Find(1);
                var subrubro2 = db.SubRubros.Find(3);
                var subrubro3 = db.SubRubros.Find(5);

                listSubrubros.Add(subrubro1);
                listSubrubros.Add(subrubro2);
                listSubrubros.Add(subrubro3);


                var oferta = new Oferta {
                    Nombre="Oferta 1",
                    Lugar= "Santiago del Estero",
                    FechaInicioConvocatoria = Convert.ToDateTime("25/08/2015"),
                    FechaFinConvocatoria   = Convert.ToDateTime("14/11/2015"),
                    Publico = true,
                    Descripcion="Oferta de prueba 1",
                    Estado="Abierta",
                    EmpleadorId = 1 ,
                    Puestos = new List<Puesto>{ //alta de puestos
                        new Puesto {
                            Nombre ="Puesto 1 - Ofeta 1",
                            CantidadDeVacantes=3,
                            Remuneracion=3000,
                            SubRubros = listSubrubros
                        }
                        //,
                        //new Puesto {
                        //    Nombre ="Puesto 2 - Ofeta 1",
                        //    CantidadDeVacantes=3,
                        //    Remuneracion=3000,
                        //    SubRubros =
                        //}
                    }
                   };

                db.Ofertas.Add(oferta);
                db.SaveChanges();
                //return Ok(listEmpleadores);
                return Ok(oferta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        // GET: api/Empleadores/5
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult GetEmpleador(int id)
        {
            Empleador empleador = db.Empleadores
                .Include(o => o.Ofertas)         
                .Include(a => a.ApplicationUsers)
                .FirstOrDefault();
            if (empleador == null)
            {
                return NotFound();
            }

            return Ok(empleador);
        }

        // PUT: api/Empleadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleador(int id, Empleador empleador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleador.Id)
            {
                return BadRequest();
            }

            db.Entry(empleador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadorExists(id))
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

        // POST: api/Empleadores
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult PostEmpleador(Empleador empleador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Empleadores.Add(empleador);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE: api/Empleadores/5
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult DeleteEmpleador(int id)
        {
            Empleador empleador = db.Empleadores.Find(id);
            if (empleador == null)
            {
                return NotFound();
            }

            db.Empleadores.Remove(empleador);
            db.SaveChanges();

            return Ok(empleador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadorExists(int id)
        {
            return db.Empleadores.Count(e => e.Id == id) > 0;
        }
    }
}