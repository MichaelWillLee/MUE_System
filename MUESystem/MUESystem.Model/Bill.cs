using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Model
{
    public class Bill : BaseModel
    {
        [Display(Name = "创建人ID")]
        public int CreatPersonID { get; set; }

        [Display(Name = "创建时间")]
        [Required(ErrorMessage = "请填写创建时间")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [DataType(DataType.DateTime)]
        public DateTime  CreatTime { get; set; }

        [Display(Name = "账单金额")]
        public Decimal BillMoney { get; set; }

        [Display(Name = "账单类型ID")]
        public int BillTypeID { get; set; }
    }
}
