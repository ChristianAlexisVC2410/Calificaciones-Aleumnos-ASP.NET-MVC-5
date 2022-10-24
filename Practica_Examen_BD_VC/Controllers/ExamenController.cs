using Practica_Examen_BD_VC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_Examen_BD_VC.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult VistaExamen()
        {
            using(EscuelaDBContext db= new EscuelaDBContext())
            {
                return View(db.Examenes.ToList());
            }
        
        }
    }
}