using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidal_ERP_System.Electronic_Invoice
{
   public class rejectedDocuments
    {      
        public string internalId { get; set; }
        public error error;
    }
   public class error
   {
       public string code { get; set; }
       public string message { get; set; }
       public string internalId { get; set; }

       public List<details> details;
   }
   public class details
   {
       public string code { get; set; }
       public string message { get; set; }      
   }

}
