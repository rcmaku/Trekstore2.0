﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trekstore.Migrations
{
    /// <inheritdoc />
    public partial class _5thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Sales");
            migrationBuilder.DropTable("Purchases");
        }
    }
}
