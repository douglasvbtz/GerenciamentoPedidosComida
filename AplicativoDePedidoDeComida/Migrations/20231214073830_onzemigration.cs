﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class onzemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemMenuId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemMenuId",
                table: "Pedidos");
        }
    }
}
