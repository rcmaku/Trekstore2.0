using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trekstore.Migrations
{
    /// <inheritdoc />
    public partial class _9thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaProveedorID",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaProveedor",
                columns: table => new
                {
                    CategoriaProveedorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaProveedorNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaProveedorDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProveedor", x => x.CategoriaProveedorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoriaProveedorID",
                table: "Providers",
                column: "CategoriaProveedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_CategoriaProveedor_CategoriaProveedorID",
                table: "Providers",
                column: "CategoriaProveedorID",
                principalTable: "CategoriaProveedor",
                principalColumn: "CategoriaProveedorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_CategoriaProveedor_CategoriaProveedorID",
                table: "Providers");

            migrationBuilder.DropTable(
                name: "CategoriaProveedor");

            migrationBuilder.DropIndex(
                name: "IX_Providers_CategoriaProveedorID",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CategoriaProveedorID",
                table: "Providers");
        }
    }
}
