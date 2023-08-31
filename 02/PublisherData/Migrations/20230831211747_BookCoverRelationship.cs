using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    /// <inheritdoc />
    public partial class BookCoverRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Cover",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cover_BookId",
                table: "Cover",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover");

            migrationBuilder.DropIndex(
                name: "IX_Cover_BookId",
                table: "Cover");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Cover");
        }
    }
}
