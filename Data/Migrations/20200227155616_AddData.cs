using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApp.Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Smartphones");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Smartphones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Smartphones",
                nullable: true);

            migrationBuilder.InsertData(
                table: "OpSystems",
                columns: new[] { "Id", "OsType" },
                values: new object[,]
                {
                    { 1, "IOS" },
                    { 2, "Android" },
                    { 3, "Harmony OS" }
                });

            migrationBuilder.InsertData(
                table: "Smartphones",
                columns: new[] { "Id", "Manufacturer", "Name", "OSId", "OperatingSystemId", "Price", "Released", "isAvailable" },
                values: new object[,]
                {
                    { 100, "Apple", "Iphone X", null, 1, "€1,500", new DateTime(2017, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 200, "Apple", "Iphone XI", null, 1, "€1,650", new DateTime(2018, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 300, "Samsung", "Samsung Galaxy S20", null, 2, "€1,400", new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 400, "Huawei", "Huawei Mate 30", null, 3, "€2,500", new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpSystems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpSystems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OpSystems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Smartphones",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Smartphones",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Smartphones",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Smartphones",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Smartphones");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Smartphones",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
