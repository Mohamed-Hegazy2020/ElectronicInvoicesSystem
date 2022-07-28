using ElectronicInvoicesSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class ItemsViewModel
    {
        [Key]
        public int UniqueId { get; set; }
        [Required(ErrorMessage = "يجب ادخال الكود ")]
        [Display(Name = "الكود")]
        public string Code { get; set; }

        [Required(ErrorMessage = "يجب ادخال لاسم ")]
        [Display(Name = "اسم الصنف")]
        public string NameAr { get; set; }   
        
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "يجب ادخال الوحدة ")]
        [Display(Name = "الوحدة")]
        public int UnitId { get; set; }


        [Required(ErrorMessage = "يجب ادخال تاريخ التسجيل ")]
        [Display(Name = "تاريخ التسجيل")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "يجب ادخال كود مصلحة الضرائب ")]
        [Display(Name = "كود مصلحة الضرائب")]
        public string ItemTaxAuthorityCode { get; set; }

        [Required(ErrorMessage = "يجب اختيار نوع كود مصلحة الضرائب ")]
        [Display(Name = "نوع الكود")]
        public string ItemTaxAuthorityType { get; set; }

        public List<Units> Units = new List<Units>();
        public List<ItemCodeType> ItemCodeType = new List<ItemCodeType>();


    }
}
