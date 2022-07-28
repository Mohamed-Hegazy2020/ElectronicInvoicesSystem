using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class TaxTypes
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal rate { get; set; }
    }
}
