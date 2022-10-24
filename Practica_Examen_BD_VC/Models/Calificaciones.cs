using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_Examen_BD_VC.Models
{
    public class Calificaciones
    {
        public int CalificacionId { get; set; }
        public double Cal { get; set; }
        //public DateTime fechaRealizacion { get; set; }
        public Alumnos Alumnos { get; set; }
    }
}