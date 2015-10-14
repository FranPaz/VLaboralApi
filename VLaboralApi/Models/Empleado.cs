using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboralApi.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Cuil { get; set; }
        public String NombreApellido { get; set; }
        public DateTime FecNacimiento { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public String ResumenCurricular { get; set; }
        public int Telefono { get; set; }
        
        //iafar: relacion muchos a muchos con subrubro
        public virtual ICollection<SubRubro> SubRubros { get; set; }


        //iafar: deberiamos poner la ocupacion aqui o en el curriculum?


        //Relacion 1 a 1
        //public int CurriculumId { get; set; }
        //public virtual Curriculum Curriculum { get; set; }
        

        //Quique: Relacion Muchos a Muchos con Puesto
        //public virtual ICollection<Puesto> Puestos { get; set; }

        

    }

    //public class Curriculum
    //{   
        
    //    public int Id { get; set; }
    //    public String Habilidades { get; set; }
    //    public String Descripcion { get; set; }

    //}

}