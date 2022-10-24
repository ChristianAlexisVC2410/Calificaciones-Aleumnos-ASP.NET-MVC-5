using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_Examen_BD_VC.Models
{
    public class Alumnos
    {
        public int MatriculaId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string ApellidoPaterno { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Cuatrimestre { get; set; }

        public double Edad { get; set; }

        public  List<Calificaciones> Calificaciones { get; set; }



        public void CalcularEdad()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan dif = fechaActual - this.FechaNacimiento;
            double dias = dif.TotalDays;
            this.Edad = Math.Floor(dias / 365);
        }

    }
}