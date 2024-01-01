using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistants.Migrations
{
    /// <inheritdoc />
    public partial class AddedthenullabilitytotheFKincarandjunktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyJunks_Companies_CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Mahan_Owji",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("986f7961-bb9e-480b-ae63-d63f5632c561"), false, "Female" },
                    { new Guid("fd96cc7e-e491-4fd5-9912-51a2a6d1f1ce"), false, "Male" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyJunks_Companies_CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                column: "CompanyId",
                principalSchema: "Mahan_Owji",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyJunks_Companies_CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks");

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("986f7961-bb9e-480b-ae63-d63f5632c561"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("fd96cc7e-e491-4fd5-9912-51a2a6d1f1ce"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Mahan_Owji",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("0de95656-76da-448d-a236-fc7db6ec122d"), false, "Male" },
                    { new Guid("e2f15e8c-ceb1-4ba3-a90b-151ed1cd42b0"), false, "Female" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyJunks_Companies_CompanyId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                column: "CompanyId",
                principalSchema: "Mahan_Owji",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
