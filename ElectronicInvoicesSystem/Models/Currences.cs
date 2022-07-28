using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class Currences
    {
        [Key]
        public int UniqueId { get; set; }
        public int Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public decimal CurncyChangeRate { get; set; }      
        public bool DefaultCurncy { get; set; }        
        public string CuruncyTaxAuthorityCode { get; set; }
    }
}
