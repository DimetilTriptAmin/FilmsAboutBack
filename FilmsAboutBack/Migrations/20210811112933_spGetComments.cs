using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAboutBack.Migrations
{
    public partial class spGetComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var spGetComments = @"create procedure GetComments
	                                @filmId int
	                                as
		                            select UserName, Avatar, Text, PublishDate, Rate from Comments 
		                            left join Ratings
		                            on Comments.UserId = Ratings.UserId
		                            left join Users
		                            on Comments.UserId = Users.Id
		                            where Comments.FilmId = @filmId
                                    return
                                    go";
            migrationBuilder.Sql(spGetComments);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetComments");
        }
    }
}
