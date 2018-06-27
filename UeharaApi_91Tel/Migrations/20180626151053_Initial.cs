using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UeharaApi_91Tel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogSistemaId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Origem = table.Column<string>(nullable: true),
                    Contexto = table.Column<string>(nullable: true),
                    Severidade = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true),
                    ArquivoFonte = table.Column<string>(nullable: true),
                    MetodoFonte = table.Column<string>(nullable: true),
                    Maquina = table.Column<string>(nullable: true),
                    LinhaFonte = table.Column<int>(nullable: true),
                    Propriedades = table.Column<string>(nullable: true),
                    Excecao = table.Column<string>(nullable: true),
                    OrigemId = table.Column<int>(nullable: true),
                    LogContextoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    NomeUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogModel");
        }
    }
}
