using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidal_ERP_System.Electronic_Invoice
{
   public class SubmissionDocumentResult
    {
       public string submissionId { get; set; }
       public List<acceptedDocuments> acceptedDocuments;
       public List<rejectedDocuments> rejectedDocuments;

    }
}
