using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistants.Migrations
{
    /// <inheritdoc />
    public partial class AddedtheDeleteBehaviouronnoaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0bb2c043-3e14-4dd3-9916-de0c6967df0d"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("c77625fc-d4e2-4c13-a947-1d0c5f239c6f"));

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("0de95656-76da-448d-a236-fc7db6ec122d"), false, "Male" },
                    { new Guid("e2f15e8c-ceb1-4ba3-a90b-151ed1cd42b0"), false, "Female" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0de95656-76da-448d-a236-fc7db6ec122d"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("e2f15e8c-ceb1-4ba3-a90b-151ed1cd42b0"));

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("0bb2c043-3e14-4dd3-9916-de0c6967df0d"), false, "Female" },
                    { new Guid("c77625fc-d4e2-4c13-a947-1d0c5f239c6f"), false, "Male" }
                });
        }
    }
}
