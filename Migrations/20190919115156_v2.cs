using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _06Fiap.Web.AspNet.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrajetoId",
                table: "Corridas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    AtletaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Profissional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.AtletaID);
                });

            migrationBuilder.CreateTable(
                name: "Medalha",
                columns: table => new
                {
                    MedalhaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CorridaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medalha", x => x.MedalhaId);
                    table.ForeignKey(
                        name: "FK_Medalha_Corridas_CorridaId",
                        column: x => x.CorridaId,
                        principalTable: "Corridas",
                        principalColumn: "CorridaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trajeto",
                columns: table => new
                {
                    TrajetoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distancia = table.Column<float>(nullable: false),
                    LocalInicio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajeto", x => x.TrajetoId);
                });

            migrationBuilder.CreateTable(
                name: "CorridaAtleta",
                columns: table => new
                {
                    CorridaId = table.Column<int>(nullable: false),
                    AtletaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorridaAtleta", x => new { x.AtletaId, x.CorridaId });
                    table.ForeignKey(
                        name: "FK_CorridaAtleta_Atleta_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atleta",
                        principalColumn: "AtletaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorridaAtleta_Corridas_CorridaId",
                        column: x => x.CorridaId,
                        principalTable: "Corridas",
                        principalColumn: "CorridaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_TrajetoId",
                table: "Corridas",
                column: "TrajetoId");

            migrationBuilder.CreateIndex(
                name: "IX_CorridaAtleta_CorridaId",
                table: "CorridaAtleta",
                column: "CorridaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medalha_CorridaId",
                table: "Medalha",
                column: "CorridaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Trajeto_TrajetoId",
                table: "Corridas",
                column: "TrajetoId",
                principalTable: "Trajeto",
                principalColumn: "TrajetoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Trajeto_TrajetoId",
                table: "Corridas");

            migrationBuilder.DropTable(
                name: "CorridaAtleta");

            migrationBuilder.DropTable(
                name: "Medalha");

            migrationBuilder.DropTable(
                name: "Trajeto");

            migrationBuilder.DropTable(
                name: "Atleta");

            migrationBuilder.DropIndex(
                name: "IX_Corridas_TrajetoId",
                table: "Corridas");

            migrationBuilder.DropColumn(
                name: "TrajetoId",
                table: "Corridas");
        }
    }
}
