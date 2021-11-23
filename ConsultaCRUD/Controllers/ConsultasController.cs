using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsultaCRUD.Models;

namespace ConsultaCRUD.Controllers
{
    public class ConsultasController : Controller
    {
        private dbConsultaCadEntities db = new dbConsultaCadEntities();

        // GET: Consultas
        public ActionResult Index()
        {
            var consulta = db.Consulta.Include(c => c.Exame).Include(c => c.Paciente);
            return View(consulta.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.ID_exame = new SelectList(db.Exame, "Id_ex", "Nome_ex");
            ViewBag.Id_paciente = new SelectList(db.Paciente, "Id_pac", "Nome_pac");
            return View();
        }

        // POST: Consultas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_consulta,Id_paciente,ID_exame,Data_consulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_exame = new SelectList(db.Exame, "Id_ex", "Nome_ex", consulta.ID_exame);
            ViewBag.Id_paciente = new SelectList(db.Paciente, "Id_pac", "Nome_pac", consulta.Id_paciente);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_exame = new SelectList(db.Exame, "Id_ex", "Nome_ex", consulta.ID_exame);
            ViewBag.Id_paciente = new SelectList(db.Paciente, "Id_pac", "Nome_pac", consulta.Id_paciente);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_consulta,Id_paciente,ID_exame,Data_consulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_exame = new SelectList(db.Exame, "Id_ex", "Nome_ex", consulta.ID_exame);
            ViewBag.Id_paciente = new SelectList(db.Paciente, "Id_pac", "Nome_pac", consulta.Id_paciente);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consulta.Find(id);
            db.Consulta.Remove(consulta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
