using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUESystem.BLL;
using MUESystem.Common.LogCommon;
using MUESystem.Common.SessionCommon;
using MUESystem.DAL;
using MUESystem.Model;
using MUESystem.Web.MUEAuthorize;
using PagedList;

namespace MUESystem.Web.Controllers
{
    public class BillsController : BaseController
    {
        private MUEDbContext db = new MUEDbContext();
        private int userID = SessionHelper.GetSeeionUserID();

        [HttpAuthorize]
        // GET: Bills
        public ActionResult Index(int page=1)
        {
            try {

                string status = EnumVal.GetStatusVal(Status.Y);
                IPagedList<Bill> pagedList = db.Bills.Where(x => x.CreatPerson.ID == userID && x.Status.Equals(status)).OrderByDescending(x => x.CreatTime).ToPagedList(page, pageSize);
                return View(pagedList);
            }catch(Exception ex){
                Log.Error("BillsController-Index",ex);
            }
            //return View(db.Bills.ToList());
            return View();
        }

        [HttpAuthorize]
        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        [HttpAuthorize]
        // GET: Bills/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpAuthorize]
        // POST: Bills/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreatTime,BillMoney,Status,Reark")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                
                bill.Status = EnumVal.GetStatusVal(Status.Y);
                if (bill.CreatPerson.ID == null) {

                }
                if (userID == null) { 
                
                }
                bill.CreatPerson.ID = userID;
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bill);
        }

        [HttpAuthorize]
        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        [HttpAuthorize]
        // POST: Bills/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreatTime,BillMoney,Status,Reark")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        [HttpAuthorize]
        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        [HttpAuthorize]
        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
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
