using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RegistroVotantes.Infraestructura.Migraciones
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nacionalidad = table.Column<string>(nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votante", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votante");
        }
    }
}