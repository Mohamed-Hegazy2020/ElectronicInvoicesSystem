using ElectronicInvoicesSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Suppliers> Supplier { get; set; }
        public DbSet<Items> Item { get; set; }
        public DbSet<ItemGroups> ItemGroup { get; set; }
        public DbSet<Units> Unit { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Currences> Currency { get; set; }
        public DbSet<InvoiceMaster> InvoiceMaster { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<TaxTypes> TaxTypes { get; set; }


    }
}
