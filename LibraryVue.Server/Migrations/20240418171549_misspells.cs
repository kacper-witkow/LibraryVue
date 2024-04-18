using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Server.Migrations
{
    /// <inheritdoc />
    public partial class misspells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumerOfPages",
                table: "Books",
                newName: "NumberOfPages");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "Books",
                newName: "Author");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPages",
                table: "Books",
                newName: "NumerOfPages");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "Autor");
        }
    }
}
