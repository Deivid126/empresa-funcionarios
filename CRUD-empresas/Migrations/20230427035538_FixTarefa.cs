using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_empresas.Migrations
{
    /// <inheritdoc />
    public partial class FixTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tarefa_funcionarios_Funcionarios_id_funcionario",
                table: "tarefa_funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_tarefa_funcionarios_Tarefas_id_tarefa",
                table: "tarefa_funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tarefa_funcionarios",
                table: "tarefa_funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_tarefa_funcionarios_id_funcionario",
                table: "tarefa_funcionarios");

            migrationBuilder.RenameTable(
                name: "tarefa_funcionarios",
                newName: "funcionarios_tarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_funcionarios_tarefa",
                table: "funcionarios_tarefa",
                columns: new[] { "id_funcionario", "id_tarefa" });

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_tarefa_id_tarefa",
                table: "funcionarios_tarefa",
                column: "id_tarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_tarefa_Funcionarios_id_funcionario",
                table: "funcionarios_tarefa",
                column: "id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_tarefa_Tarefas_id_tarefa",
                table: "funcionarios_tarefa",
                column: "id_tarefa",
                principalTable: "Tarefas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_tarefa_Funcionarios_id_funcionario",
                table: "funcionarios_tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_tarefa_Tarefas_id_tarefa",
                table: "funcionarios_tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_funcionarios_tarefa",
                table: "funcionarios_tarefa");

            migrationBuilder.DropIndex(
                name: "IX_funcionarios_tarefa_id_tarefa",
                table: "funcionarios_tarefa");

            migrationBuilder.RenameTable(
                name: "funcionarios_tarefa",
                newName: "tarefa_funcionarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tarefa_funcionarios",
                table: "tarefa_funcionarios",
                columns: new[] { "id_tarefa", "id_funcionario" });

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_funcionarios_id_funcionario",
                table: "tarefa_funcionarios",
                column: "id_funcionario");

            migrationBuilder.AddForeignKey(
                name: "FK_tarefa_funcionarios_Funcionarios_id_funcionario",
                table: "tarefa_funcionarios",
                column: "id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tarefa_funcionarios_Tarefas_id_tarefa",
                table: "tarefa_funcionarios",
                column: "id_tarefa",
                principalTable: "Tarefas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
