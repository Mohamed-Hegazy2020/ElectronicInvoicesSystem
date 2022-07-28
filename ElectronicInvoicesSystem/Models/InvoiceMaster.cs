using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class InvoiceMaster
    {
        [Key]
        public int id { get; set; }
        public int code { get; set; }
        public DateTime date { get; set; }
        public int customerId { get; set; }
        public int supplierId { get; set; }
        public int curuncyId { get; set; }
        public decimal invTotal { get; set; }
        public decimal invDiscount { get; set; }
        public decimal invTotalAfterDiscount { get; set; }
        public decimal invTax { get; set; }
        public decimal invNet { get; set; }
        public string invState { get; set; }
        public string uuid { get; set; }
        public string DocType { get; set; }



    }
}
