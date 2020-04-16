using Microsoft.EntityFrameworkCore.Migrations;

namespace HangMANFinal.Data.Migrations
{
    public partial class migrace2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hadanapismena",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slovo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "uhodnutaslova",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "slova",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slovo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slova", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slova");

            migrationBuilder.DropColumn(
                name: "hadanapismena",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "slovo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "uhodnutaslova",
                table: "AspNetUsers");
        }
    }
}
