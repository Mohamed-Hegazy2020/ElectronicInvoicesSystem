using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class Suppliers
    {
        [Key]
        public int UniqueId { get; set; } 
        public string Code { get; set; } 
        public DateTime CreationDate { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }       
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; } 
        public string BranchTaxAuthorityCode { get; set; }
        public string NationalID { get; set; }
        public string ClassType { get; set; }
        public string CountryCode { get; set; }
        public string Governate { get; set; }
        public string RegionCity { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string IDType { get; set; } 
        public bool Active { get; set; } 
    }
}
