using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboralApi.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set;}
        public DateTime FechaInicioConvocatoria { get; set; }
        public DateTime FechaFinConvocatoria { get; set; }
        public Boolean Publico { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        //Quique: Relacion Uno a Muchos con Empleador
        public int EmpleadorId { get; set; }
        public virtual Empleador Empleador { get; set; }

        //iafar: Relacion uno a muchos con Puestos(muchos)
        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}