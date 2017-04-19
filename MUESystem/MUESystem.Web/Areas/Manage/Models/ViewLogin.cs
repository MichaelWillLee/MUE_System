using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MUESystem.Web.Areas.Manage.Models
{
    public class ViewLogin
    {
        [Required(ErrorMessage="请填写登录名")]
        [Display(Name="帐号")]
        public string LoginName { get; set; }

        [Required(ErrorMessage="请填写密码")]
        [Display(Name="密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}