using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class twomorecomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "UserId" },
                values: new object[] { new DateTime(2021, 7, 27, 12, 53, 4, 56, DateTimeKind.Local).AddTicks(3588), 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FilmId", "PublishDate", "Text", "UserId" },
                values: new object[,]
                {
                    { 2, 3, new DateTime(2021, 7, 27, 12, 53, 4, 57, DateTimeKind.Local).AddTicks(692), "Shittiest shit ever! Don't waste your time!", 2 },
                    { 3, 3, new DateTime(2021, 7, 27, 12, 53, 4, 57, DateTimeKind.Local).AddTicks(723), "Should I watch it or not?", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "89bae6c5-f43e-423c-9fbd-f6b5349907c7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "08c96d91-a8fe-4a41-9275-74415e00f7bc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4ab6210a-7990-4b31-92cf-cbc73ef4f54b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "993d4153-e107-4e34-9594-d57b31403e87");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "5c9225e8-941a-4c38-bef1-bd8b06b14a43");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "UserId" },
                values: new object[] { new DateTime(2021, 7, 27, 12, 44, 35, 21, DateTimeKind.Local).AddTicks(751), 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3debe2ad-b1c7-43b3-8be7-0137f76c4517");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0d5ef133-01cc-403d-b414-f87f31989c9f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "032bb07c-e1b9-4bb3-9439-edfafcce1429");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "5d00a387-d6a5-4bca-9905-b6241de6aa65");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "b4cf0535-d559-40cb-968a-467644d6b853");
        }
    }
}
