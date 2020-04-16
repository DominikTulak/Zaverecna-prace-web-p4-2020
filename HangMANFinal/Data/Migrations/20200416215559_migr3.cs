using Microsoft.EntityFrameworkCore.Migrations;

namespace HangMANFinal.Data.Migrations
{
    public partial class migr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aktualnistavslova",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aktualnistavslova",
                table: "AspNetUsers");
        }
    }
}
