using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Model
{
    public class BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "状态")]
        /// <summary>
        /// 状态
        /// Y正常、N锁定
        /// </summary>
        public string Status { get; set; }

        [Display(Name = "备注")]
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Reark { get; set; }
    }
}
