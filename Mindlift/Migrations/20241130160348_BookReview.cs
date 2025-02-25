using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindlift.Migrations
{
    /// <inheritdoc />
    public partial class BookReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReview");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "DocId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doc",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPagesMedian = table.Column<long>(type: "bigint", nullable: true),
                    PublishDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAmazon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingsAverage = table.Column<double>(type: "float", nullable: true),
                    RatingsCount = table.Column<long>(type: "bigint", nullable: true),
                    WantToReadCount = table.Column<long>(type: "bigint", nullable: true),
                    CurrentlyReadingCount = table.Column<long>(type: "bigint", nullable: true),
                    AlreadyReadCount = table.Column<long>(type: "bigint", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibraryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doc", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_Doc_Library_LibraryID",
                        column: x => x.LibraryID,
                        principalTable: "Library",
                        principalColumn: "LibraryID",
                        onDelete: ReferentialAction.NoAction); // Change from Cascade to NoAction
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_DocId",
                table: "Review",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_LibraryId",
                table: "Review",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Doc_LibraryID",
                table: "Doc",
                column: "LibraryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Doc_DocId",
                table: "Review",
                column: "DocId",
                principalTable: "Doc",
                principalColumn: "DocId",
                onDelete: ReferentialAction.NoAction); // Change from Cascade to NoAction

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Library_LibraryId",
                table: "Review",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "LibraryID",
                onDelete: ReferentialAction.NoAction); // Change from Cascade to NoAction
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Doc_DocId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Library_LibraryId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropIndex(
                name: "IX_Review_DocId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_LibraryId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "DocId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingsAvg = table.Column<double>(type: "float", nullable: false),
                    RatingsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "BookReview",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReviewsReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReview", x => new { x.BookId, x.ReviewsReviewId });
                    table.ForeignKey(
                        name: "FK_BookReview_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReview_Review_ReviewsReviewId",
                        column: x => x.ReviewsReviewId,
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_ReviewsReviewId",
                table: "BookReview",
                column: "ReviewsReviewId");
        }
    }
}
