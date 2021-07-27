using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class addedtrailerlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrailerLink",
                value: "https://www.youtube.com/watch?v=O1nDozs-LxI&ab_channel=FilmFeed");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrailerLink",
                value: "https://www.youtube.com/watch?v=7pQQHnqBa2E&ab_channel=FaceOff");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrailerLink",
                value: "https://www.youtube.com/watch?v=Ify9S7hj480&ab_channel=MovieclipsTrailers");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrailerLink",
                value: "https://www.youtube.com/watch?v=s7EdQ4FqbhY&ab_channel=Movieclips");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "TrailerLink",
                value: "https://www.youtube.com/watch?v=40hHA9n4C2o&ab_channel=MovieclipsClassicTrailers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "119116a6-6652-4c9f-a5db-a4e4f87b1d3d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b425ab02-8256-4d71-bbe6-4e248de3f9ac");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a1ceaf29-f557-47c0-90f9-27c43241ca45");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "83555f52-741c-432e-9569-380cec3d730d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "79cc7ee2-5a8c-4f46-a363-4748350df768");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrailerLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrailerLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrailerLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrailerLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "TrailerLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7c3c8f25-1b11-42d6-a86a-d0219fcd7589");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "564f9381-6d61-456a-a305-4d9ef04976c5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f3a84055-022b-4ba0-a229-997655805e21");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "65fd4b5f-2df7-4d8a-a871-0740d9a6a76b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "3897b266-0ef0-4b27-96e4-3c92c4f21c47");
        }
    }
}
