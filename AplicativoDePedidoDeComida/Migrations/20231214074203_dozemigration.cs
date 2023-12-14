using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class dozemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosItensMenu",
                table: "PedidosItensMenu");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PedidosItensMenu",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosItensMenu",
                table: "PedidosItensMenu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItensMenu_PedidoId",
                table: "PedidosItensMenu",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosItensMenu",
                table: "PedidosItensMenu");

            migrationBuilder.DropIndex(
                name: "IX_PedidosItensMenu_PedidoId",
                table: "PedidosItensMenu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PedidosItensMenu");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosItensMenu",
                table: "PedidosItensMenu",
                columns: new[] { "PedidoId", "ItemMenuId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
