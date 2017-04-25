using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Model
{
    public class Bank
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 银行名
        /// </summary>
        [Required(ErrorMessage="银行名称必须有")]
        [Display(Name="银行")]
        public string BankName { get; set; }

        /// <summary>
        /// 状态
        /// Y正常、N锁定
        /// </summary>
        [Required(ErrorMessage="状态")]
        [Display(Name="状态")]
        public string Status { get; set; }
    }
}
