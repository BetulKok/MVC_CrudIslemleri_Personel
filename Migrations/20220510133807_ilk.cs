using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_CrudIslemleri_Personel.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departmanlar",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Muhasabe" },
                    { 2, "Bilgi İşlem" },
                    { 3, "Pazarlama" },
                    { 4, "İnsan Kaynakları" },
                    { 5, "Planlama ve Yönetim" },
                    { 6, "Lojistik" },
                    { 7, "İdari" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "Departmanlar");
        }
    }
}
