using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supplier A" },
                    { 2, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supplier B" },
                    { 3, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supplier C" },
                    { 4, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supplier D" },
                    { 5, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supplier E" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Brand", "Model", "RegistrationDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Toyota", "Corolla", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "BMW", "X5", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Tesla", "Model 3", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Audi", "A4", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "Honda", "Civic", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "Ford", "Focus", new DateTime(2018, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Mercedes", "C-Class", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, "Volkswagen", "Passat", new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, "Hyundai", "Elantra", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, "Kia", "Ceed", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 11, "Nissan", "Altima", new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "Chevrolet", "Cruze", new DateTime(2018, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "Mazda", "3", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, "Skoda", "Octavia", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, "Renault", "Megane", new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
