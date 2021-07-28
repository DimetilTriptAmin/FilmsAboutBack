using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class userseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 12, 56, 6, 405, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 12, 56, 6, 407, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 12, 56, 6, 407, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "ef098189-eeaf-40ea-bf31-dd60f5fd38d3", "user1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "60cf6f67-bfe9-4756-b22a-0794464e3673", "user2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "b1d3330e-03ac-48ae-bf88-8c7c945a6aa2", "user3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "80db85bc-c28f-4bdc-96a7-27339cf40c16", "user4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "0f79b164-2f25-46fb-9d56-0ba2d26697c8", "user5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "ee6422d1-4c2f-4f54-84ed-86370c2f02f3", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "92adade8-7ec2-45f8-8859-947810affa15", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "f3bafef1-48ad-42ed-a6f0-86c3440b9cb3", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "35e6c661-56e2-4efe-8771-c59caab5c1ea", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "a458c2d6-0cc8-4f86-b9e8-65cc5cd0673c", null });
        }
    }
}
