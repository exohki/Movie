using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRatingPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                schema: "dbo",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                schema: "dbo",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UserId",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Occupations_OccupationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                schema: "dbo",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupations",
                schema: "guest",
                table: "Occupations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Ratings",
                schema: "dbo",
                newName: "ratings",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Occupations",
                schema: "guest",
                newName: "occupations",
                newSchema: "guest");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users",
                newSchema: "guest");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "userdetails",
                newSchema: "guest");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies",
                newSchema: "guest");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                schema: "dbo",
                table: "ratings",
                newName: "IX_ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieId",
                schema: "dbo",
                table: "ratings",
                newName: "IX_ratings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OccupationId",
                schema: "guest",
                table: "users",
                newName: "IX_users_OccupationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserId",
                schema: "guest",
                table: "userdetails",
                newName: "IX_userdetails_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                schema: "dbo",
                table: "ratings",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ratings",
                schema: "dbo",
                table: "ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_occupations",
                schema: "guest",
                table: "occupations",
                column: "OccupationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "guest",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userdetails",
                schema: "guest",
                table: "userdetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                schema: "guest",
                table: "movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_movies_MovieId",
                schema: "dbo",
                table: "ratings",
                column: "MovieId",
                principalSchema: "guest",
                principalTable: "movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_users_UserId",
                schema: "dbo",
                table: "ratings",
                column: "UserId",
                principalSchema: "guest",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userdetails_users_UserId",
                schema: "guest",
                table: "userdetails",
                column: "UserId",
                principalSchema: "guest",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_occupations_OccupationId",
                schema: "guest",
                table: "users",
                column: "OccupationId",
                principalSchema: "guest",
                principalTable: "occupations",
                principalColumn: "OccupationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ratings_movies_MovieId",
                schema: "dbo",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_users_UserId",
                schema: "dbo",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_userdetails_users_UserId",
                schema: "guest",
                table: "userdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_users_occupations_OccupationId",
                schema: "guest",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ratings",
                schema: "dbo",
                table: "ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_occupations",
                schema: "guest",
                table: "occupations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "guest",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userdetails",
                schema: "guest",
                table: "userdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                schema: "guest",
                table: "movies");

            migrationBuilder.RenameTable(
                name: "ratings",
                schema: "dbo",
                newName: "Ratings",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "occupations",
                schema: "guest",
                newName: "Occupations",
                newSchema: "guest");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "guest",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "userdetails",
                schema: "guest",
                newName: "UserDetails");

            migrationBuilder.RenameTable(
                name: "movies",
                schema: "guest",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_ratings_UserId",
                schema: "dbo",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ratings_MovieId",
                schema: "dbo",
                table: "Ratings",
                newName: "IX_Ratings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_users_OccupationId",
                table: "Users",
                newName: "IX_Users_OccupationId");

            migrationBuilder.RenameIndex(
                name: "IX_userdetails_UserId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                schema: "dbo",
                table: "Ratings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                schema: "dbo",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupations",
                schema: "guest",
                table: "Occupations",
                column: "OccupationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                schema: "dbo",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                schema: "dbo",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Occupations_OccupationId",
                table: "Users",
                column: "OccupationId",
                principalSchema: "guest",
                principalTable: "Occupations",
                principalColumn: "OccupationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
