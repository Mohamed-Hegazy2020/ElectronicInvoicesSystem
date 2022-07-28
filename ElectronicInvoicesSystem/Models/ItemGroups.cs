using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class ItemGroups
    {
        [Key]
        public int UniqueId { get; set; }
        public short Code { get; set; }        
        public string NameEn { get; set; }
        public string NameAr { get; set; }      
        public DateTime CreationDate { get; set; }
       
    }
}
