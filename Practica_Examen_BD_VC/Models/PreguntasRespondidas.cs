using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_Examen_BD_VC.Models
{
    public class PreguntasRespondidas
    {
        public int RespondidaId { get; set; }
        public int OpcionSeleccionada { get; set; }
        public Examenes Examenes { get; set; }

    }
}