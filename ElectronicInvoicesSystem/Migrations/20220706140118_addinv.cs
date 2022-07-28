using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicInvoicesSystem.Migrations
{
    public partial class addinv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masterId = table.Column<int>(type: "int", nullable: false),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    itemValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discountRate = table.Column<int>(type: "int", nullable: false),
                    discountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    taxType = table.Column<int>(type: "int", nullable: false),
                    taxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    taxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    itemNetValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceMaster",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: false),
                    curuncyId = table.Column<int>(type: "int", nullable: false),
                    invTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invTotalAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invNet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uuid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceMaster", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceMaster");
        }
    }
}
