using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTaiSan.Migrations
{
    /// <inheritdoc />
    public partial class QuanLyTaiSan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TEN_NV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUAN_LY_BOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIA_CHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIOI_TINH = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiSan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_TAI_SAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TEN_TAI_SAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOAI_TAI_SAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TaiSan");
        }
    }
}
