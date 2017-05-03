using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUESystem.DAL;
using MUESystem.Model;

namespace MUESystem.Web.Controllers
{
    public class DictionariesController : Controller
    {
        private MUEDbContext db = new MUEDbContext();

        // GET: Dictionaries
        public ActionResult Index()
        {
            return View(db.Dictionarys.ToList());
        }

        // GET: Dictionaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dictionary dictionary = db.Dictionarys.Find(id);
            if (dictionary == null)
            {
                return HttpNotFound();
            }
            return View(dictionary);
        }

        // GET: Dictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dictionaries/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status,Reark,FirstCode,SecondCode,ThirdCode,FourthCode,FifthCode,InfoValue")] Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                db.Dictionarys.Add(dictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dictionary);
        }

        // GET: Dictionaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dictionary dictionary = db.Dictionarys.Find(id);
            if (dictionary == null)
            {
                return HttpNotFound();
            }
            return View(dictionary);
        }

        // POST: Dictionaries/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status,Reark,FirstCode,SecondCode,ThirdCode,FourthCode,FifthCode,InfoValue")] Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dictionary);
        }

        // GET: Dictionaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dictionary dictionary = db.Dictionarys.Find(id);
            if (dictionary == null)
            {
                return HttpNotFound();
            }
            return View(dictionary);
        }

        // POST: Dictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dictionary dictionary = db.Dictionarys.Find(id);
            db.Dictionarys.Remove(dictionary);
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
