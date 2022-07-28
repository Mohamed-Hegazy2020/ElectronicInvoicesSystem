using ElectronicInvoicesSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.ModelsView
{
    public class DocumentsMasterRpt
    {
        [Key]
        public int id { get; set; }   
        [Display(Name = "رقم المستند")]
        public int code { get; set; }

        [Display(Name = "تاريخ المستند")]
        public DateTime docDate { get; set; }

        [Display(Name = "من تاريخ")]
        public DateTime fDate { get; set; }

        [Display(Name = "إلي تاريخ")]
        public DateTime tDate { get; set; }

        [Display(Name = "اسم المشتري")]
        public int customerId { get; set; }     

        [Display(Name = "نوع المستند")]
        public string DocType { get; set; }

        [Display(Name = "حالة المستند")]
        public string DocState { get; set; }

        [Display(Name = "نوع المستند")]
        public string DocTypeName { get; set; }

        [Display(Name = "اسم العميل")]
        public string customerName { get; set; }

        [Display(Name = "العملة")]
        public string curuncyName { get; set; }

        [Display(Name = "البائع")]
        public string companyName { get; set; }

        [Display(Name = "إجمالي المستند")]
        public decimal invTotal { get; set; }

        [Display(Name = "قيمة الخصم")]
        public decimal invDiscount { get; set; }   

        [Display(Name = "قيمة الضريبة")]
        public decimal invTax { get; set; }

        [Display(Name = "صافي المستند")]
        public decimal invNet { get; set; }

        [Display(Name = "حالة المستند")]
        public string DocStateName { get; set; }

        public string codeFilter { get; set; }
        public string DocStateNameFilter { get; set; }
        public string DocTypeNameFilter { get; set; }
        public string customerNameFilter { get; set; }



        public List<Customers> customers { get; set; }
       

        public List<DocTypes> DocTypes = new List<DocTypes>()
        {
             new DocTypes(){ name="الكل",id="a"},
            new DocTypes(){ name="فاتورة",id="I"},
            new DocTypes(){ name="إشعار دائن",id="C"},
            new DocTypes(){ name="إشعار مدين",id="D"},
        };
        public List<DocStates> DocStates = new List<DocStates>()
        {
            new DocStates(){ name="الكل",id="a"},
            new DocStates(){ name="صالح",id="Valid"},
            new DocStates(){ name="غير صالح",id="Invalid"},
            new DocStates(){ name="ملغي",id="Canceled"},
            new DocStates(){ name="لم يحدد بعد",id="notConfermed"},
        };

    }
}
