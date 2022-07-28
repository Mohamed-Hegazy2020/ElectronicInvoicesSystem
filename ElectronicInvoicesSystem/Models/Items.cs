using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class Items
    {
        [Key]
        public int UniqueId { get; set; }
        public string Code { get; set; }
        public int GroupId { get; set; }       
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public double MinQty { get; set; }
        public double MaxQty { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
        public int UnitId { get; set; }       
        public DateTime CreationDate { get; set; }      
        public string ItemTaxAuthorityCode { get; set; }
        public string ItemTaxAuthorityType { get; set; }
    }
}
