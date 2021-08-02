using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class etnorma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 30, 14, 7, 27, 673, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 30, 14, 7, 27, 674, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 30, 14, 7, 27, 674, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "b5431157-520c-46ff-ad43-be459fed2e62", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "422f9051-2f5b-4053-80f1-ef93f274d1c9", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "b12f300e-1f81-41fd-ac0a-7e07c664bbee", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "e012200e-31d5-4c17-bb5e-e9495de31eb1", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "a8c27cdf-1d32-4047-abaa-654c5fbf95d7", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "f3946408-e336-4c49-889a-14cd33deca06", null });
        }
    }
}
