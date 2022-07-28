using ElectronicInvoicesSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class InvoiceDetailsViewModel
    {
        [Key]
        public int id { get; set; }
        public int masterId { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "اسم الصنف")]
        public int itemId { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "الكمية")]
        public decimal Qty { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "الوحدة")]
        public int unitId { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "السعر")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "قيمة الصنف")]
        public decimal itemValue { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "نسبة الخصم")]
        public int discountRate { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "قيمة الخصم")]
        public decimal discountValue { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "نوع الضريبة")]
        public int taxType { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "نسبة الضريبة")]
        public decimal taxRate { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "قيمة الضريبة")]
        public decimal taxValue { get; set; }
        [Required(ErrorMessage = "حقل ألزامي")]
        [Display(Name = "صافي القيمة")]
        public int itemNetValue { get; set; }

        [Display(Name = "اسم الصنف")]
        public string itemName { get; set; }
        [Display(Name = "الوحدة")]
        public string unitName { get; set; }

        public List<Units> Units { get; set; }      
        public List<Items> Items { get; set; }
        public List<TaxTypes> TaxTypes { get; set; }
    }
}
