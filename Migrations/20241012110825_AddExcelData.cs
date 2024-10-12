using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Migrations
{
    /// <inheritdoc />
    public partial class AddExcelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YourEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Field1 = table.Column<string>(type: "TEXT", nullable: false),
                    Field2 = table.Column<string>(type: "TEXT", nullable: false),
                    Field3 = table.Column<string>(type: "TEXT", nullable: false),
                    Field4 = table.Column<string>(type: "TEXT", nullable: false),
                    Field5 = table.Column<string>(type: "TEXT", nullable: false),
                    Field6 = table.Column<string>(type: "TEXT", nullable: false),
                    Field7 = table.Column<string>(type: "TEXT", nullable: false),
                    Field8 = table.Column<string>(type: "TEXT", nullable: false),
                    Field9 = table.Column<string>(type: "TEXT", nullable: false),
                    Field10 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YourEntities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YourEntities");
        }
    }
}
