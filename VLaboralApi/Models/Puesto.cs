using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboralApi.Models
{
    public class Puesto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int CantidadDeVacantes { get; set; }
        public int Remuneracion { get; set; }

        //iafar: Relacion 1 a muchos con Oferta(uno)
        public int OfertaId { get; set; }
        public virtual Oferta Oferta { get; set; }
        
        //Quique: Relacion muchos a muchos con SubRubro
        public virtual ICollection<SubRubro> SubRubros { get; set; }

        //Quique: Relacion Uno a Uno con Requisito
        //public int RequisitoId { get; set; }
        //public virtual Requisito Requisito { get; set; }               

        //Quique: Relacion Muchos a Muchos con Empleado
        //public virtual ICollection<Empleado> Empleados { get; set; }

        //Relacion Uno a Muchos con Disponibilidad
        //public int DisponibilidadId { get; set; }
        //public virtual Disponibilidad Disponibilidad { get; set; }

        //Quique: Relacion uno a muchos con TipoDeContrato
        //public int TipoDeContratoId { get; set; }
        //public virtual TipoDeContrato TipoDeContrato { get; set; }

        

    }

    //public class Requisito
    //{
    //    public int Id { get; set; }
    //    public String Habilidad { get; set; }
    //    public int Edad { get; set; }
    //    public Boolean FinEstudio { get; set; }
    //    public int AñosDeExperiencia { get; set; }
    //    public string DistanciaAlTrabajo { get; set; }
    //    public Boolean Movilidad { get; set; }
    //    public String Adicionales { get; set; }

    //    //Quique: Relacion uno a uno con Puesto
    //    public int PuestoId { get; set; }
    //    //public virtual Puesto Puesto { get; set; }

    //    //Quique: Relacion Uno a Muchos con Idioma
    //    //public int IdiomaId { get; set; }
    //    //public virtual Idioma Idioma { get; set; }

    //    ////Quique: Relacion Uno a Muchos con NivelIdioma
    //    //public int IdiomaNivelId { get; set; }
    //    //public virtual IdiomaNivel IdiomaNivel { get; set; }

    //    ////Quique: Relacion uno a muchos con Profesion
    //    //public int ProfesionId { get; set; }
    //    //public virtual Profesion Profesion { get; set; }

    //    ////iafar: relacion uno a muchos con Nivel de estudio(1)
    //    //public int NivelDeEstudioId { get; set; }
    //    //public virtual NivelDeEstudio NivelDeEstudio { get; set; }

    //}

    //public class Idioma
    //{
    //    public int Id { get; set; }
    //    public String NombreIdioma { get; set; }
    //    //iafar: relacion 1 a muchos con Requisitos(muchos)
    //    //public virtual ICollection<Requisito> Requisitos { get; set; }

    //}

    //public class IdiomaNivel
    //{
    //    public int Id { get; set; }
    //    public String NombreIdiomaNivel { get; set; }

    //}

    //public class NivelDeEstudio
    //{
    //    public int Id { get; set; }
    //    public String NombreNivelDeEstudio { get; set; }

    //    //iafar: relacion 1 a muchos con requisitos(muchos)
    //    //public virtual ICollection<Requisito> Requisitos { get; set; }

    //}


}