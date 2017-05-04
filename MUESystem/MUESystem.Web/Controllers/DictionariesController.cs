using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUESystem.Common.LogCommon;
using MUESystem.DAL;
using MUESystem.Model;
using MUESystem.Web.MUEAuthorize;
using PagedList;

namespace MUESystem.Web.Controllers
{
    public class DictionariesController : BaseController
    {
        private MUEDbContext db = new MUEDbContext();

        [HttpAuthorize]
        // GET: Dictionaries
        public ActionResult Index(int page = 1)
        {
            try {
                //IPagedList<User> pagedList = userService.Entities.OrderBy(x => x.ID).ToPagedList(page, pageSize);

                IPagedList<Dictionary> pagedList = db.Dictionarys.OrderBy(x => x.ID).ToPagedList(page,pageSize);
                //将分页处理后的列表传给View  
                return View(pagedList);
            }
            catch (Exception ex) {
                Log.Error("DictionariesController-Index",ex);
                return View();
            }
           

           
            //return View(db.Dictionarys.ToList());自动生成
        }

        [HttpAuthorize]
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

        [HttpAuthorize]
        // GET: Dictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpAuthorize]
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

        [HttpAuthorize]
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

        [HttpAuthorize]
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

        [HttpAuthorize]
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

        [HttpAuthorize]
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

        [HttpAuthorize]
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
