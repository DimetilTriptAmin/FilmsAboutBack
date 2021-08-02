using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class tesst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 23, 37, 891, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 23, 37, 891, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 23, 37, 891, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "4fc1f71f-2bde-4d79-98b2-d21d1475baf7", "USER1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "a5739605-0a65-4303-bd3b-d2a7e54f3d94", "USER2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "972815de-07aa-4bf6-aa85-9c3a8e31ba22", "USER3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "21d56873-9063-4cf3-95ca-257583d1c095", "USER4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "10402a16-f138-4564-9f78-e58cd1817ab2", "USER5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "2755131f-a03b-4803-8bcc-dca678ffefff", "JOKER228" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 19, 12, 389, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 19, 12, 390, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 8, 2, 15, 19, 12, 390, DateTimeKind.Local).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "e745476d-c241-4803-9ce9-4a31504d3110", "user1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "6ccd1705-e3b1-44eb-98b7-94c5a5f1561d", "user2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "1b04b873-76aa-4e6b-a57a-3f06f9026053", "user3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "07e62eda-52f2-45a8-97f1-cd9b4dff4a99", "user4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "f7cf5597-1e71-4007-9eb3-14f3c196ab09", "user5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "8e81bf26-656c-4fed-bcb0-2c79f89cd1df", "joker228" });
        }
    }
}
