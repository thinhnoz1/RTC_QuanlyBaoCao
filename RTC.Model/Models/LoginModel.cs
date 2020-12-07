using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Model.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Chưa nhập email !!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Chưa nhập password !!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
