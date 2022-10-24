using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_Examen_BD_VC.Models
{
    public class Examenes
    {
        public int PreguntaId { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string NombrePregunta { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Respuesta1 { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Respuesta2 { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Respuesta3 { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Respuesta4 { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string RespuestaCorrecta { get; set; }
        public virtual List<PreguntasRespondidas> PreguntasRespondidas { get; set; }
        

    }
}