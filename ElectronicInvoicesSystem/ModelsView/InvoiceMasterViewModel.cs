using ElectronicInvoicesSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class InvoiceMasterViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم المستند ")]
        [Display(Name = "رقم المستند")]
        public int code { get; set; }

        [Required(ErrorMessage = "يجب اختيار التاريخ ")]
        [Display(Name = "تاريخ المستند")]
        public DateTime date { get; set; }


        [Required(ErrorMessage = " يجب اختيار مشتري")]
        [Display(Name = "اسم المشتري")]
        public int customerId { get; set; }

        public int supplierId { get; set; }

        [Required(ErrorMessage = "يجب اختيار العملة")]
        [Display(Name = "العملة")]
        public int curuncyId { get; set; }

        [Required(ErrorMessage = "يجب ادخال اجمالي المستند")]
        [Display(Name = "إجمالي المستند")]
        public decimal invTotal { get; set; }
      
        [Display(Name = "قيمة الخصم")]
        public decimal invDiscount { get; set; }
     
        [Display(Name = "قيمة المستند بعد الخصم")]
        public decimal invTotalAfterDiscount { get; set; }

       
        [Display(Name = "قيمة الضريبة")]
        public decimal invTax { get; set; }

        [Display(Name = "صافي المستند")]
        public decimal invNet { get; set; }
       
        [Display(Name = "حالة المستند")]
        public string invState { get; set; }
      
        [Display(Name = "رقم التعريف الفريد")]
        public string uuid { get; set; }

        [Required(ErrorMessage = "يجب اختيار اختيار نوع المستند")]
        [Display(Name = "نوع المستند")]
        public string DocType { get; set; }

        [Display(Name = "نوع المستند")]
        public string DocTypeName { get; set; }
        [Display(Name = "اسم العميل")]
        public string customerName { get; set; }
        [Display(Name = "العملة")]
        public string curuncyName { get; set; }

        [Display(Name = "البائع")]
        public string companyName { get; set; }

        public List<Customers> customers { get; set; }
        public List<Suppliers> Suppliers { get; set; }
        public List<Currences> Currences { get; set; }
        public List<Items> Items { get; set; }
        public List<Units> Units { get; set; }
        public List<InvoiceDetailsViewModel> InvoiceDetails { get; set; }

        public List<DocTypes> DocTypes = new List<DocTypes>()
        {
            new DocTypes(){ name="فاتورة",id="I"},
            new DocTypes(){ name="إشعار دائن",id="C"},
            new DocTypes(){ name="إشعار مدين",id="D"},
        };

    }
}
