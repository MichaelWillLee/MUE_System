using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUESystem.DAL;
using MUESystem.Model;

namespace MUESystem.Web.ModelsView
{
    public class BillIndexlList
    {
        public int ID { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserName { get; set; }

        public string BillType { get; set; }

        public decimal money { get; set; }

        public string remark { get; set; }
    }
    public class ViewBill
    {
        public Bill bill { get; set; }

        public User user { get; set; }

        public string typeID { get; set; }

        /// <summary>
        /// 选中的消费类型
        /// </summary>
       public  IEnumerable<SelectListItem> GetSelectList()
       {
            MUEDbContext db = new MUEDbContext();
            List<Model.Dictionary> seriesList = db.Dictionarys.Where(x=>x.Status.Equals("Y") && x.FirstCode.Equals("cost") && x.SecondCode.Length>1).ToList();
            SelectList selectList = new SelectList(seriesList, "ID", "InfoValue");
            return selectList;
        }
     } 
}