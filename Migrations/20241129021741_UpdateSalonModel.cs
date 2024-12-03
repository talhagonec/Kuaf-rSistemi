using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforIsletmeYonetim.Migrations
{
    public partial class UpdateSalonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalismaSaatleri",
                table: "Salonlar");

            migrationBuilder.DropColumn(
                name: "Tur",
                table: "Salonlar");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Salonlar",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Salonlar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Salonlar",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Salonlar");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Salonlar");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Salonlar",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CalismaSaatleri",
                table: "Salonlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tur",
                table: "Salonlar",
                type: "text",
                nullable: true);
        }
    }
}
