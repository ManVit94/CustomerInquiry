using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInquiry.DataAccess.Migrations
{
    public partial class InitTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "ContactEmail", "CustomerName", "MobileNo" },
                values: new object[] { 1, "cust1@gmail.com", "Customer 1", 385551 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "ContactEmail", "CustomerName", "MobileNo" },
                values: new object[] { 2, "cust2@gmail.com", "Customer 2", 385552 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "CurrencyCode", "CustomerID", "Status", "TransactionTime" },
                values: new object[,]
                {
                    { 1, 200m, "USD", 1, 1, new DateTime(2019, 1, 12, 14, 34, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 300m, "USD", 1, 1, new DateTime(2019, 1, 7, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1200m, "EUR", 1, 1, new DateTime(2019, 4, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 100m, "USD", 2, 3, new DateTime(2019, 3, 12, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 500m, "USD", 2, 2, new DateTime(2019, 3, 7, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 700m, "EUR", 2, 1, new DateTime(2019, 4, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);
        }
    }
}
