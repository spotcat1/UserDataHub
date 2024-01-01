using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistants.Migrations
{
    /// <inheritdoc />
    public partial class AddedtheonDeletBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                schema: "Mahan_Owji",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyJunks_Users_UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                schema: "Mahan_Owji",
                table: "Users");

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("49243096-d2f2-4b91-9776-d89386cb7fe3"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8441631c-0fe1-4841-9f30-100a8049f55b"));

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("0bb2c043-3e14-4dd3-9916-de0c6967df0d"), false, "Female" },
                    { new Guid("c77625fc-d4e2-4c13-a947-1d0c5f239c6f"), false, "Male" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                schema: "Mahan_Owji",
                table: "Cars",
                column: "UserId",
                principalSchema: "Mahan_Owji",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyJunks_Users_UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                column: "UserId",
                principalSchema: "Mahan_Owji",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                schema: "Mahan_Owji",
                table: "Users",
                column: "GenderId",
                principalSchema: "Mahan_Owji",
                principalTable: "Genders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                schema: "Mahan_Owji",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyJunks_Users_UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                schema: "Mahan_Owji",
                table: "Users");

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
                    { new Guid("49243096-d2f2-4b91-9776-d89386cb7fe3"), false, "Male" },
                    { new Guid("8441631c-0fe1-4841-9f30-100a8049f55b"), false, "Female" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                schema: "Mahan_Owji",
                table: "Cars",
                column: "UserId",
                principalSchema: "Mahan_Owji",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyJunks_Users_UserId",
                schema: "Mahan_Owji",
                table: "UserCompanyJunks",
                column: "UserId",
                principalSchema: "Mahan_Owji",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                schema: "Mahan_Owji",
                table: "Users",
                column: "GenderId",
                principalSchema: "Mahan_Owji",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
