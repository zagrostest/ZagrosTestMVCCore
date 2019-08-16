using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrosTestProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(24, MinimumLength = 3)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
