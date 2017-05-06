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
using MUESystem.Web.ModelsView;
using MUESystem.Web.MUEAuthorize;
using PagedList;

namespace MUESystem.Web.Controllers
{
    public class BillsController : BaseController
    {
        private MUEDbContext db = new MUEDbContext();

        [HttpAuthorize]
        // GET: Bills
        public ActionResult Index(int page=1)
        {
            try
            {
                var query = from b in db.Bills.Where(x => x.CreatPersonID == userID && x.Status.Equals(statusY))
                            join u in db.Users.Where(x=>x.ID==userID && x.Status.Equals(statusY))
                            on b.CreatPersonID equals u.ID
                            join d in db.Dictionarys.Where(x=>x.FirstCode.Equals("cost")&& x.Status.Equals(statusY))
                            on b.BillTypeID equals d.ID
                            orderby b.CreatTime descending
                            select new BillIndexlList { ID = b.ID, CreateTime = b.CreatTime, UserName = u.DisplayName, BillType = d.InfoValue,money = b.BillMoney,remark=b.Reark };
                var list = query.ToList<BillIndexlList>();

                IPagedList<BillIndexlList> pagedList = list.ToPagedList(page, pageSize);

                //将分页处理后的列表传给View  
                return View(pagedList);
            }
            catch (Exception ex) {
                Log.Error("BillsController-index",ex);
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
            ViewBill viewBillCreat = new ViewBill();
            viewBillCreat.bill = new Bill();

            return View(viewBillCreat);
        }

        [HttpAuthorize]
        // POST: Bills/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewBill viewBillCreat, string CreatTime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewBillCreat.bill.Status = statusY;
                    viewBillCreat.bill.CreatPersonID = userID;
                    viewBillCreat.bill.CreatTime = Convert.ToDateTime(CreatTime);
                    string billTypeid = viewBillCreat.typeID;
                    viewBillCreat.bill.BillTypeID =Convert.ToInt32(billTypeid);
                    db.Bills.Add(viewBillCreat.bill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) {
                Log.Error("BillsController-Create-Post",ex);
                return View();
            }
            return View();
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
        public ActionResult Edit([Bind(Include = "ID,CreatPersonID,CreatTime,BillMoney,BillTypeID,Status,Reark")] Bill bill)
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
