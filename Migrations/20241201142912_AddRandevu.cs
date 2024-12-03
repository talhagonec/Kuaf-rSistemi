using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforIsletmeYonetim.Migrations
{
    public partial class AddRandevu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Randevu tablosunda gerekli sütunları oluşturuyoruz
            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusteriAdi = table.Column<string>(nullable: false),
                    CalisanId = table.Column<int>(nullable: false),
                    BaslangicSaati = table.Column<DateTime>(nullable: false),
                    BitisSaati = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevular_Calisanlar_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular",
                column: "CalisanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geri alma işlemi
            migrationBuilder.DropTable(name: "Randevular");
        }
    }
}
