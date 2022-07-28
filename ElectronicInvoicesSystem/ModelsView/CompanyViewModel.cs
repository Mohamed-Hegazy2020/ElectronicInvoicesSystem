using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class CompanyViewModel
    {
        [Key]
        public int UniqueId { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        [Display(Name = "الاسم")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "يجب ادخال تاريخ التسجيل")]
        [Display(Name = "تاريخ التسجيل")]
        public DateTime CreationDate { get; set; }
       
        //[Display(Name = "الكود")]
        //public string imagePath { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم التسجيل الضريبي")]
        [Display(Name = "رقم التسجيل الضريبي")]
        public string TaxAuthorityRegestrationNumber { get; set; }

        [Required(ErrorMessage = "يجب ادخال نوع النشاط")]
        [Display(Name = "نوع النشاط")]
        public string TaxPayerActivityCode { get; set; }

        [Required(ErrorMessage = "يجب ادخال فئة الشركة")]
        [Display(Name = "الفئة")]
        public string ClassType { get; set; }

        [Required(ErrorMessage = "يجب ادخال كود الدولة")]
        [Display(Name = "كود الدولة")]
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

        [Required(ErrorMessage = "يجب ادخال رقم المبني ")]
        [Display(Name = "رقم المبني")]
        public string BuildingNumber { get; set; }

        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني")]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم التليفون")]
        [Display(Name = "رقم التليفون")]
        public string Phone { get; set; }
     

        [Required(ErrorMessage = "يجب ادخال Client_ID")]
        [Display(Name = "Client_ID")]
        public string Client_ID { get; set; }

        [Required(ErrorMessage = "يجب ادخال Client_Secret")]
        [Display(Name = "Client_Secret")]
        public string Client_Secret { get; set; }

        [Required(ErrorMessage = "يجب ادخال TokenPassword")]
        [Display(Name = "TokenPassword")]
        public string TokenPassword { get; set; }

        public List<ClassType> ClassTypes = new List<ClassType>()
         {

            new ClassType{code="B",name="شركة B"},
            new ClassType{code="P",name="شخص مصري P"},
            new ClassType{code="F", name="شخص أجنبي F"},
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
