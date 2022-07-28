using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int id { get; set; }      
        public int masterId { get; set; }      
        public int itemId { get; set; } 
        public decimal Qty { get; set; }
        public int unitId { get; set; }
        public decimal price { get; set; }
        public decimal itemValue { get; set; }
        public int discountRate { get; set; }
        public decimal discountValue { get; set; }
        public int taxType { get; set; }
        public decimal taxRate { get; set; }
        public decimal taxValue { get; set; }
        public int itemNetValue { get; set; }


    }
}
