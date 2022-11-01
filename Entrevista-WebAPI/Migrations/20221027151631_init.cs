using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entrevista_WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioCargos",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioCargos", x => new { x.FuncionarioId, x.CargoId });
                    table.ForeignKey(
                        name: "FK_FuncionarioCargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioCargos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[] { 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 1, 1, "Matemática" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 2, 2, "Física" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 3, 3, "Português" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 4, 4, "Inglês" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 5, 5, "Programação" });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "FuncionarioCargos",
                columns: new[] { "CargoId", "FuncionarioId" },
                values: new object[] { 5, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioCargos_CargoId",
                table: "FuncionarioCargos",
                column: "CargoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioCargos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
