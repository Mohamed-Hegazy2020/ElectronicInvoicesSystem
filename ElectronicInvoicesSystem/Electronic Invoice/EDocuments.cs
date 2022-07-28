using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidal_ERP_System.Electronic_Invoice
{
    public class EDocuments
    {
        public int id { get; set; }
        public string docType { get; set; }
        public int docCode { get; set; }
        public DateTime docDate { get; set; }
        public string issuer { get; set; }
        public string receiver { get; set; }
        public string docState { get; set; }
        public string uuid { get; set; }

      
    }
}
