using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDI_kodetest_revised.Migrations
{
    /// <inheritdoc />
    public partial class Modellendringer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_FullmektigId",
                table: "Saker");

            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_KontaktId",
                table: "Saker");

            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_SøkerId",
                table: "Saker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saker",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_FullmektigId",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_KontaktId",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_SøkerId",
                table: "Saker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personer",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "FullmektigId",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "KontaktId",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "SøkerId",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "VedtaksId",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "ExternalIdField",
                table: "Personer");

            migrationBuilder.AlterColumn<string>(
                name: "SakId",
                table: "Saker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FullmektigPersonnummer",
                table: "Saker",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KontaktPersonnummer",
                table: "Saker",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoekerPersonnummer",
                table: "Saker",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Personnummer",
                table: "Personer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saker",
                table: "Saker",
                column: "SakId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personer",
                table: "Personer",
                column: "Personnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_FullmektigPersonnummer",
                table: "Saker",
                column: "FullmektigPersonnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_KontaktPersonnummer",
                table: "Saker",
                column: "KontaktPersonnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_SoekerPersonnummer",
                table: "Saker",
                column: "SoekerPersonnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_FullmektigPersonnummer",
                table: "Saker",
                column: "FullmektigPersonnummer",
                principalTable: "Personer",
                principalColumn: "Personnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_KontaktPersonnummer",
                table: "Saker",
                column: "KontaktPersonnummer",
                principalTable: "Personer",
                principalColumn: "Personnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_SoekerPersonnummer",
                table: "Saker",
                column: "SoekerPersonnummer",
                principalTable: "Personer",
                principalColumn: "Personnummer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_FullmektigPersonnummer",
                table: "Saker");

            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_KontaktPersonnummer",
                table: "Saker");

            migrationBuilder.DropForeignKey(
                name: "FK_Saker_Personer_SoekerPersonnummer",
                table: "Saker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saker",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_FullmektigPersonnummer",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_KontaktPersonnummer",
                table: "Saker");

            migrationBuilder.DropIndex(
                name: "IX_Saker_SoekerPersonnummer",
                table: "Saker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personer",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "FullmektigPersonnummer",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "KontaktPersonnummer",
                table: "Saker");

            migrationBuilder.DropColumn(
                name: "SoekerPersonnummer",
                table: "Saker");

            migrationBuilder.AlterColumn<string>(
                name: "SakId",
                table: "Saker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Saker",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FullmektigId",
                table: "Saker",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KontaktId",
                table: "Saker",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SøkerId",
                table: "Saker",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VedtaksId",
                table: "Saker",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Personnummer",
                table: "Personer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Personer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ExternalIdField",
                table: "Personer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saker",
                table: "Saker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personer",
                table: "Personer",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_FullmektigId",
                table: "Saker",
                column: "FullmektigId",
                principalTable: "Personer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_KontaktId",
                table: "Saker",
                column: "KontaktId",
                principalTable: "Personer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saker_Personer_SøkerId",
                table: "Saker",
                column: "SøkerId",
                principalTable: "Personer",
                principalColumn: "Id");
        }
    }
}
