using Practica_Examen_BD_VC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_Examen_BD_VC.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult VistaAlumnos()
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                //select *from alumnos
                return View(db.Alumnos.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumnos alum)
        {
            try
            {
                alum.CalcularEdad();
                using (EscuelaDBContext db = new EscuelaDBContext())
                {
                    //select *from alumnos
                    db.Alumnos.Add(alum);
                    db.SaveChanges();
                }
                return RedirectToAction("VistaAlumnos");
            }
            catch (Exception)
            {
                return View();
            }

        }

        public ActionResult Edit(int? Id)
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                //select *from alumnos
                return View(db.Alumnos.Where(x => x.MatriculaId == Id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Edit(int? Id, Alumnos alum)
        {
            try
            {
                using (EscuelaDBContext db = new EscuelaDBContext())

                {
                    alum.CalcularEdad();
                    db.Entry(alum).State = EntityState.Modified;
                 
                    db.SaveChanges();
                }

                return RedirectToAction("VistaAlumnos");
            }
            catch (Exception)
            {
                return View();
            }


        }

        public ActionResult Delete(int? Id)
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                //select *from alumnos
                return View(db.Alumnos.Where(x => x.MatriculaId == Id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Delete(int? Id, Alumnos alum)
        {
            try
            {
                using (EscuelaDBContext db = new EscuelaDBContext())
                {
                    Alumnos alum1 = db.Alumnos.Where(x => x.MatriculaId == Id).FirstOrDefault();
                    db.Alumnos.Remove(alum1);
                    db.SaveChanges();
                    return RedirectToAction("VistaAlumnos");
                }
            }
            catch (Exception)
            {
                return View();
            }

        }

        public ActionResult BuscarAlumno(string Nombre,string ApellidoPaterno)
        {
            
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
       
                List<Alumnos> query = new List<Alumnos>();
                if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(ApellidoPaterno))
                {
                  
                    query = db.Alumnos.Where(x => x.Nombre.Contains(Nombre) && x.ApellidoPaterno.Contains(ApellidoPaterno)).ToList();
                }
         
                    if (query.Count == 0)
                    {
                    ViewBag.mensaje = "No hay registro";
                        return View("BuscarAlumno");
                     }
                
              
                

             
                return View(query);


            }

        }

      

    }
}