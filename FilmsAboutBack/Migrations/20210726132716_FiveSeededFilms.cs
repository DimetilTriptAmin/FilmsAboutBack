using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class FiveSeededFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", 4.7000000000000002, "Fight Club" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.", 4.7999999999999998, "Scarface" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "An American expat tries to sell off his highly profitable marijuana empire in London, triggering plots, schemes, bribery and blackmail in an attempt to steal his domain out from under him.", 4.5, "Gentlemen" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 4.9000000000000004, "Pulp Fiction" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "An exceptionally adept Florida lawyer is offered a job at a high-end New York City law firm with a high-end boss - the biggest opportunity of his career to date.", 4.2000000000000002, "The Devil's Advocate" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "film #1", 0.0, "film1" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "film #2", 0.0, "film2" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "film #3", 0.0, "film3" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "film #4", 0.0, "film4" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Rating", "Title" },
                values: new object[] { "film #5", 0.0, "film5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4c8f11b1-e671-4836-a720-ce17d4c424c0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "101744a1-ca6e-492a-b4c1-dd563e37b28b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1e1e4788-e877-48c0-8415-42d65aca4def");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "249727c0-2308-4eef-b104-f51cc1cbd31a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "1ab4e5dc-7119-4b62-9fa7-00cd2ed03225");
        }
    }
}
