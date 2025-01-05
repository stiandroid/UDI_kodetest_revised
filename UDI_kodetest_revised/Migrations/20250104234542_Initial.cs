using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDI_kodetest_revised.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalIdField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etternavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mellomnavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobilnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reisedokumentnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fødselsdato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poststed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vedtak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GyldigFra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GyldigTil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vedtak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecNo = table.Column<int>(type: "int", nullable: false),
                    SakId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendtSms = table.Column<bool>(type: "bit", nullable: false),
                    KontaktId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullmektigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SøkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VedtaksId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VedtakId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saker_Personer_FullmektigId",
                        column: x => x.FullmektigId,
                        principalTable: "Personer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saker_Personer_KontaktId",
                        column: x => x.KontaktId,
                        principalTable: "Personer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saker_Personer_SøkerId",
                        column: x => x.SøkerId,
                        principalTable: "Personer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saker_Vedtak_VedtakId",
                        column: x => x.VedtakId,
                        principalTable: "Vedtak",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saker_FullmektigId",
                table: "Saker",
                column: "FullmektigId");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_KontaktId",
                table: "Saker",
                column: "KontaktId");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_SøkerId",
                table: "Saker",
                column: "SøkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_VedtakId",
                table: "Saker",
                column: "VedtakId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saker");

            migrationBuilder.DropTable(
                name: "Personer");

            migrationBuilder.DropTable(
                name: "Vedtak");
        }
    }
}
