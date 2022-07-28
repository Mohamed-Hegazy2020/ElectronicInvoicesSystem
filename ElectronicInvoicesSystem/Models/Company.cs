using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Models
{
    public class Company
    {
        [Key]
        public int UniqueId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }       
        public DateTime CreationDate { get; set; }      
        public string imagePath { get; set; } 
        public string TaxAuthorityRegestrationNumber { get; set; }
        public string TaxPayerActivityCode { get; set; }
        public string ClassType { get; set; }
        public string CountryCode { get; set; }
        public string Governate { get; set; }
        public string RegionCity { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }       
        public string Client_ID { get; set; }
        public string Client_Secret { get; set; }
        public string TokenPassword { get; set; }
    }
}
