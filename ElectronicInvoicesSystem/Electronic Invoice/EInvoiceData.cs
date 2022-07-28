using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidal_ERP_System.Electronic_Invoice
{
   public class EInvoiceData
    {
        public string documentType { get; set; }
        public string documentTypeVersion { get; set; }
        public string dateTimeIssued { get; set; }
        public string taxpayerActivityCode { get; set; }
        public string internalID { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; } 
        public string salesOrderDescription { get; set; }
        public string proformaInvoiceNumber { get; set; }
        public double totalDiscountAmount { get; set; }
        public double totalSalesAmount { get; set; }
        public double netAmount { get; set; }
        public double totalAmount { get; set; }
        public double extraDiscountAmount { get; set; }
        public double totalItemsDiscountAmount { get; set; }       
        public issuer issuer { get; set; }
        public receiver receiver { get; set; }
        public List<invoiceLines> invoiceLines { get; set; }
        public List<taxTotals> taxTotals { get; set; }
        //public List<signatures> signatures { get; set; }
       
    }
}
