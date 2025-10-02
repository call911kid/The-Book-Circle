using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Book_Circle.Migrations
{
    /// <inheritdoc />
    public partial class X : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_genresID",
                table: "BookGenre");

            migrationBuilder.RenameColumn(
                name: "genresID",
                table: "BookGenre",
                newName: "GenresID");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_genresID",
                table: "BookGenre",
                newName: "IX_BookGenre_GenresID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenresID",
                table: "BookGenre",
                column: "GenresID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenresID",
                table: "BookGenre");

            migrationBuilder.RenameColumn(
                name: "GenresID",
                table: "BookGenre",
                newName: "genresID");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_GenresID",
                table: "BookGenre",
                newName: "IX_BookGenre_genresID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_genresID",
                table: "BookGenre",
                column: "genresID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
