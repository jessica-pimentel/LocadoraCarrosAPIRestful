using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraCarros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class domingoManha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlugado",
                table: "Carro",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Carro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Carro",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsAlugado", "Status" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Carro",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsAlugado", "Status" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Carro",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsAlugado", "Status" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Carro",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsAlugado", "Status" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Carro",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsAlugado", "Status" },
                values: new object[] { false, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlugado",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Carro");
        }
    }
}
