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
        [Display(Name = "创建人")]
        public User CreatPerson { get; set; }

        [Display(Name = "创建时间")]
        [Required(ErrorMessage = "请填写创建时间")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime CreatTime { get; set; }

        [Display(Name = "账单金额")]
        public Decimal BillMoney { get; set; }

        
        public Dictionary BillType { get; set; }
    }
}
