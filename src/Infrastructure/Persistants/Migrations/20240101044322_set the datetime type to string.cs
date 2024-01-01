﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistants.Migrations
{
    /// <inheritdoc />
    public partial class setthedatetimetypetostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2455d6a4-5236-4acc-a031-17835b8420f7"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("907e5906-d524-4a27-b1d9-4b558667a0f1"));

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                schema: "Mahan_Owji",
                table: "Users",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                schema: "Mahan_Owji",
                table: "Companies",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                schema: "Mahan_Owji",
                table: "Cars",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("9b4244b5-01d1-4982-9ce2-0dafc4a139cf"), false, "Female" },
                    { new Guid("c51c3c4a-71e0-495a-a907-b0c46c5f4b70"), false, "Male" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("9b4244b5-01d1-4982-9ce2-0dafc4a139cf"));

            migrationBuilder.DeleteData(
                schema: "Mahan_Owji",
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("c51c3c4a-71e0-495a-a907-b0c46c5f4b70"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                schema: "Mahan_Owji",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "Mahan_Owji",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Mahan_Owji",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.InsertData(
                schema: "Mahan_Owji",
                table: "Genders",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("2455d6a4-5236-4acc-a031-17835b8420f7"), false, "Male" },
                    { new Guid("907e5906-d524-4a27-b1d9-4b558667a0f1"), false, "Female" }
                });
        }
    }
}
