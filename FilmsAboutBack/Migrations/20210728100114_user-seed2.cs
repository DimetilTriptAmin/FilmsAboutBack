using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class userseed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Avatar",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { null, "ef098189-eeaf-40ea-bf31-dd60f5fd38d3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { null, "60cf6f67-bfe9-4756-b22a-0794464e3673" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { null, "b1d3330e-03ac-48ae-bf88-8c7c945a6aa2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { null, "80db85bc-c28f-4bdc-96a7-27339cf40c16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Avatar", "ConcurrencyStamp" },
                values: new object[] { null, "0f79b164-2f25-46fb-9d56-0ba2d26697c8" });
        }
    }
}
