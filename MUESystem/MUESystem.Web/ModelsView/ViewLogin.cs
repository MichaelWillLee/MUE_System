using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MUESystem.Web.ModelsView
{
    public class ViewLogin
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "4-20个数字和字母")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}