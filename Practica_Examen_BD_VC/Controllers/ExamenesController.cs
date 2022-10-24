using Practica_Examen_BD_VC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_Examen_BD_VC.Controllers
{
    public class ExamenesController : Controller
    {
        // GET: Examenes
        public ActionResult VistaExamenes()
        {
            using (EscuelaDBContext db = new EscuelaDBContext())
            {
                //select *from alumnos
                return View(db.Examenes.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Examenes exa)
        {
            try
            {
  
                using (EscuelaDBContext db = new EscuelaDBContext())
                {
                    //select *from alumnos
                    db.Examenes.Add(exa);
                    db.SaveChanges();
                }
                return RedirectToAction("VistaExamenes");
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
                return View(db.Examenes.Where(x => x.PreguntaId == Id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Edit(int? Id, Examenes exa)
        {
            try
            {
                using (EscuelaDBContext db = new EscuelaDBContext())

                {
                   
                    db.Entry(exa).State = EntityState.Modified;

                    db.SaveChanges();
                }

                return RedirectToAction("VistaExamenes");
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
                return View(db.Examenes.Where(x => x.PreguntaId == Id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Delete(int? Id, Examenes exam)
        {
            try
            {
                using (EscuelaDBContext db = new EscuelaDBContext())
                {
                    Examenes exam1 = db.Examenes.Where(x => x.PreguntaId == Id).FirstOrDefault();
                    db.Examenes.Remove(exam1);
                    db.SaveChanges();
                    return RedirectToAction("VistaExamenes");
                }
            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}