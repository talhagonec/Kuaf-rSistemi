using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforIsletmeYonetim.Migrations
{
    public partial class FixCalisanAndSalonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "UzmanlikAlani",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Calisanlar",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Calisanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Salonlar",
                columns: new[] { "Id", "Ad", "Adres", "Telefon" },
                values: new object[] { 1, "Kuaför A", "Adres A", "0123456789" });

            migrationBuilder.InsertData(
                table: "Calisanlar",
                columns: new[] { "Id", "Ad", "SalonId" },
                values: new object[,]
                {
                    { 1, "Ahmet Yılmaz", 1 },
                    { 2, "Ayşe Demir", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_SalonId",
                table: "Calisanlar",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Salonlar_SalonId",
                table: "Calisanlar",
                column: "SalonId",
                principalTable: "Salonlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Salonlar_SalonId",
                table: "Calisanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_SalonId",
                table: "Calisanlar");

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salonlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Calisanlar",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Calisanlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UzmanlikAlani",
                table: "Calisanlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
