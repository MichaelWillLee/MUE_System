using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Model
{
    public class Dictionary : BaseModel
    {
        [Required(ErrorMessage = "值必填")]
        [Display(Name = "一级纬度")]
        /// <summary>
        /// 一级纬度编码
        /// </summary>
        public string FirstCode { get; set; }

        [Display(Name = "二级纬度")]
        /// <summary>
        /// 二级纬度编码
        /// </summary>
        public string SecondCode { get; set; }

        [Display(Name = "三级纬度")]
        /// <summary>
        /// 三级纬度
        /// </summary>
        public string ThirdCode { get; set; }

        [Display(Name = "四级纬度")]
        /// <summary>
        /// 四级纬度
        /// </summary>
        public string FourthCode { get; set; }

        [Display(Name = "五级纬度")]
        /// <summary>
        /// 五级纬度
        /// </summary>
        public string FifthCode { get; set; }

        [Required(ErrorMessage="值必填")]
        [Display(Name = "信息值")]
        /// <summary>
        /// 值
        /// </summary>
        public string InfoValue { get; set; }
    }
}
