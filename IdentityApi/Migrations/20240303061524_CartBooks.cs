using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    /// <inheritdoc />
    public partial class CartBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Carts_CartId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CartId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "CartBooks",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartBooks", x => new { x.CartId, x.BookId });
                    table.ForeignKey(
                        name: "FK_CartBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartBooks_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartBooks_BookId",
                table: "CartBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartBooks");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CartId",
                table: "Books",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Carts_CartId",
                table: "Books",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
