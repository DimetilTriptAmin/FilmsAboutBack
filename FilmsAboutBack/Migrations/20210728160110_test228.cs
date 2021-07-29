using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class test228 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 19, 1, 10, 185, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 19, 1, 10, 185, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 19, 1, 10, 185, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\Img\\default-avatar.jpg", "7a5a8287-7a4a-4167-8661-54c7e9a9d733" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\Img\\default-avatar.jpg", "000b96ac-d5ec-4232-aaf9-973f8cb5867f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\Img\\default-avatar.jpg", "d9591d63-9a0e-460c-a496-790819c69837" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\Img\\default-avatar.jpg", "3c8374d3-8593-40fd-86cf-1dfe861e17db" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\Img\\default-avatar.jpg", "1fb68433-36df-438c-af6d-87da9ffa9dbc" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 10, 0, "D:\\Projects\\FilmsAbout\\FilmsAboutBack\\Assets\\7080332121072814524.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "18df319a-0d6b-4929-8d55-00535e3f2a2b", null, false, false, null, null, null, null, null, false, null, false, "joker228" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 13, 1, 13, 858, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 13, 1, 13, 859, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 7, 28, 13, 1, 13, 859, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "E:\\ITechArt\\films-about-back\\Assets\\Img\\default-avatar.jpg", "49292986-669a-4c9b-a4a6-ee0a0437d5b6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "E:\\ITechArt\\films-about-back\\Assets\\Img\\default-avatar.jpg", "d1be62db-b118-4bbc-a111-4db7d0288441" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "E:\\ITechArt\\films-about-back\\Assets\\Img\\default-avatar.jpg", "9738cc39-c507-4ce5-9e23-c3836211b45e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "E:\\ITechArt\\films-about-back\\Assets\\Img\\default-avatar.jpg", "02c98528-e878-42f8-b5b1-e66475e435ce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { "E:\\ITechArt\\films-about-back\\Assets\\Img\\default-avatar.jpg", "762f19fc-9183-4864-b252-1c2606438174" });
        }
    }
}
