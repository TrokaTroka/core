using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrokaTroka.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    IdBook = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IdCategory = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.IdBook, x.IdCategory });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TradeStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeUser",
                columns: table => new
                {
                    IdUser = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IdTrade = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeUser", x => new { x.IdUser, x.IdTrade });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<string>(type: "text", nullable: true),
                    AvatarName = table.Column<string>(type: "text", nullable: true),
                    AvatarPath = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Isbn = table.Column<string>(type: "text", nullable: false),
                    Publisher = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdUser = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IdTrade = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    IdRater = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IdRated = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_IdRated",
                        column: x => x.IdRated,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotosBooks",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdBook = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosBooks_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdUser",
                table: "Books",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosBooks_IdBook",
                table: "PhotosBooks",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IdRated",
                table: "Ratings",
                column: "IdRated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PhotosBooks");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "TradeUser");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
