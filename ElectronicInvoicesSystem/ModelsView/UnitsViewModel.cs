using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class UnitsViewModel
    {
        [Key]
        public int UniqueId { get; set; }

        [Required(ErrorMessage = "يجب ادخال الكود ")]
        [Display(Name = "الكود")]
        public int Code { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        [Display(Name = "الاسم")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "يجب ادخال تاريخ التسجيل ")]
        [Display(Name = "تاريخ التسجيل")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "يجب ادخال كود مصلحة الضرايب")]
        [Display(Name = "كود مصلحة الضرايب")]
        public string UnitTaxAuthorityCode { get; set; }
    }
}
