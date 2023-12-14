using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class decimamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PedidosItensMenu",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ItemMenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosItensMenu", x => new { x.PedidoId, x.ItemMenuId });
                    table.ForeignKey(
                        name: "FK_PedidosItensMenu_ItensMenu_ItemMenuId",
                        column: x => x.ItemMenuId,
                        principalTable: "ItensMenu",
                        principalColumn: "ItemMenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosItensMenu_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItensMenu_ItemMenuId",
                table: "PedidosItensMenu",
                column: "ItemMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropTable(
                name: "PedidosItensMenu");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }
    }
}
