using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class ratingseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 3, 12, 45, 438, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 3, 12, 45, 439, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 3, 12, 45, 439, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "FilmId", "UserId", "Rate" },
                values: new object[,]
                {
                    { 3, 1, 4 },
                    { 3, 2, 1 },
                    { 3, 3, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ee6422d1-4c2f-4f54-84ed-86370c2f02f3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "92adade8-7ec2-45f8-8859-947810affa15");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f3bafef1-48ad-42ed-a6f0-86c3440b9cb3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "35e6c661-56e2-4efe-8771-c59caab5c1ea");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "a458c2d6-0cc8-4f86-b9e8-65cc5cd0673c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "FilmId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "FilmId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "FilmId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 27, 12, 53, 4, 56, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 27, 12, 53, 4, 57, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 27, 12, 53, 4, 57, DateTimeKind.Local).AddTicks(723));

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
    }
}
