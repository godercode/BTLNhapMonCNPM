using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhapMonCNPM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypeComparedPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ComparedPrice",
                table: "Drinks",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ComparedPrice",
                table: "Drinks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
