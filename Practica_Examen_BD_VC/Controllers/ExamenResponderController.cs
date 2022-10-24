using Practica_Examen_BD_VC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Practica_Examen_BD_VC.Controllers
{

    public class ExamenResponderController : Controller
    {
        // GET: ExamenResponder

        public ActionResult ResponderExamenAlumno(int? Id)
        {

            using (EscuelaDBContext db = new EscuelaDBContext())
            {


                //select *from alumnos
                var exam=db.Examenes.ToList();
                var examenes = new List<Examenes>();

                ViewBag.MiListado = exam;

                return View(db.Alumnos.Where(x => x.MatriculaId == Id).FirstOrDefault());
            }
        }


        public ActionResult _VExamenResponder()
        {

            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                //select *from alumnos
                return View(db.Examenes.ToList());
            }
         
        }

        [HttpPost]
        public ActionResult _VExamenResponder(FormCollection exa,int MatriculaId)
        {


            List<string> respondida = new List<string>();
            List<string> listaCorrecta = new List<string>();
           
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                var result = db.Examenes.Count();
                //select *from alumnos
             
                double cal=0 ;
                var contCorrecto = 0;
                var contIncoCorrecto = 0;
                var cont=0;
                for (int i=1; i<=result;i++)
                {
                    var respuestaSola = exa[""+i+""];// agarra todo el post del html pero tomamos i del for en la cual esta iterando la lista de result que contine examenes
                    var respuestaCorrectas = exa["r_" + i + ""];// 
                    respondida.Add(respuestaSola);

                    listaCorrecta.Add(respuestaCorrectas);

                    if (respuestaCorrectas== respuestaSola)
                    {
                    
                        contCorrecto += 1;
                    }
                    else
                    {
                        contIncoCorrecto += 0;
                    }
                    cont += 1;

                }
            
                cal = ((double)contCorrecto / (double)cont) * 10;
                var alum = new Alumnos();
                alum.MatriculaId = Convert.ToInt32(MatriculaId);
                db.Alumnos.Attach(alum);

                var calif = new Calificaciones();
                calif.Alumnos = alum;
                calif.Cal = cal;
                db.Calificaciones.Add(calif);
                db.SaveChanges();


                return RedirectToAction("vistaCalificacion");
            }

        }


        public ActionResult vistaCalificacion()
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {

                var calificaciones = db.Calificaciones.Include(p => p.Alumnos).ToList();
                ViewBag.Grupos1 = db.Alumnos.Select(m => m.Cuatrimestre).Distinct().ToList();
                return View(calificaciones.ToList());
            }


        }

        [HttpPost]
        public ActionResult vistaCalificacion(string Grupo)
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {

                ViewBag.Grupos1 = db.Alumnos.Select(m => m.Cuatrimestre).Distinct().ToList();

                var calificaciones= db.Calificaciones.Include(p => p.Alumnos).ToList();
                calificaciones.Where(x => x.Alumnos.Cuatrimestre == Grupo);
                var query = calificaciones.Where(x => x.Alumnos.Cuatrimestre.Contains(Grupo)).ToList();

               
                return View(query);
            }
               

        }


    }
}