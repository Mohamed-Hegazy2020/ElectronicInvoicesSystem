using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class SuppliersViewModel
    {     
        [Key]
        public int UniqueId { get; set; }

        [Required(ErrorMessage = "يجب ادخال كود المورد")]
        [Display(Name = "الكود")]
        public string Code { get; set; }

        [Required(ErrorMessage = "يجب اختيار تاريخ التسجيل")]
        [Display(Name = "تاريخ التسجيل")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        [Display(Name = "الاسم")]
        public string NameAr { get; set; }

        [Display(Name = "العنوان")]
        public string Address { get; set; }

        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string Tel { get; set; }

        [Display(Name = "رقم الموبيل")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "يجب ادخال نوع الهوية")]
        [Display(Name = "نوع الهوية")]
        public string IDType { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم الهوية")]
        [Display(Name = "رقم الهوية")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "يجب ادخال فئة المورد")]
        [Display(Name = "فئة المورد")]
        public string ClassType { get; set; }

        [Required(ErrorMessage = "يجب ادخال الدولة")]
        [Display(Name = "الدولة")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "يجب ادخال المحافظة")]
        [Display(Name = "المحافظة")]
        public string Governate { get; set; }

        [Required(ErrorMessage = "يجب ادخال المنطقة")]
        [Display(Name = "المنطقة")]
        public string RegionCity { get; set; }

        [Required(ErrorMessage = "يجب ادخال الشارع")]
        [Display(Name = "الشارع")]
        public string Street { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم المبني")]
        [Display(Name = "رقم المبني")]
        public string BuildingNumber { get; set; }

        public List<ClassType> ClassTypes = new List<ClassType>()
         {
            new ClassType{code="B",name="شركة B"},
            new ClassType{code="P",name="شخص مصري P"},
            new ClassType{code="F", name="شخص أجنبي F"},
         };

        public List<IDType> IDTypes = new List<IDType>()
          {
             new IDType{code="NAT",name="رقم قومي"},
             new IDType{code="TIN",name="رقم تسجيل ضريبي"},
             new IDType { code = "IQA", name = "رقم إقامة" },
             new IDType { code = "PAS", name = "رقم جواز سفر" },
          };
        public List<Countries> Countries = new List<Countries>()
          {
             new Countries{code="EG",name="مصر"},
             new Countries{code="SA",name="السعودية"},
             new Countries { code = "AE", name = "الامارات" },
             new Countries { code = "KW", name = "الكويت" },
          };

    }
}
