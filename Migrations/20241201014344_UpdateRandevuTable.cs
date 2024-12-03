using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforIsletmeYonetim.Migrations
{
    public partial class UpdateRandevuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RandevuId",
                table: "Randevular",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_RandevuId",
                table: "Randevular",
                column: "RandevuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Randevular_RandevuId",
                table: "Randevular",
                column: "RandevuId",
                principalTable: "Randevular",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Randevular_RandevuId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_RandevuId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "RandevuId",
                table: "Randevular");
        }
    }
}
