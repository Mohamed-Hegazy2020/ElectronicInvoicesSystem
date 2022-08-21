using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "اسم المستخدم")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Please Enter the Confirm Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Pwd")]
        public string Confirmpwd { get; set; }

        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
    }
}
