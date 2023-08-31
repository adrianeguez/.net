using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    /// <inheritdoc />
    public partial class ViewAuthorsByArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_ArtistCover_ArtistsArtistId",
                table: "ArtistCover",
                column: "ArtistsArtistId");

            migrationBuilder.Sql(
                @"CREATE VIEW AuthorsByArtist
                AS
                SELECT Artist.FirstName + ' ' + Artist.LastName as Artist,
                        Authors.FirstName + ' ' + Authors.LastName AS Author
                FROM Artist LEFT JOIN
                ArtistCover ON Artist.ArtistId = ArtistCover.ArtistsArtistId LEFT JOIN
                Cover ON ArtistCover.CoversCoverId = Cover.CoverId LEFT JOIN
                Books ON Books.BookId = Cover.BookId LEFT JOIN
                Authors ON Books.AuthorId = Authors.AuthorId
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX IX_ArtistCover_ArtistsArtistId");
            migrationBuilder.Sql("DROP VIEW AuthorsByArtist");
        }
    }
}
