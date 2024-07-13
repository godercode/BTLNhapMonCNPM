using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhapMonCNPM.Migrations
{
    /// <inheritdoc />
    public partial class AddComparedTotalToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ComparedTotal",
                table: "Bills",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComparedTotal",
                table: "Bills");
        }
    }
}
