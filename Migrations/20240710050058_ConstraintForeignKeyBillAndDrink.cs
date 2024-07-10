using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhapMonCNPM.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintForeignKeyBillAndDrink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Bills",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTotalCompared",
                table: "BillDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_DrinkId",
                table: "BillDetails",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_BillId",
                table: "BillDetails",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Drinks_DrinkId",
                table: "BillDetails",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_BillId",
                table: "BillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Drinks_DrinkId",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_DrinkId",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SubTotalCompared",
                table: "BillDetails");
        }
    }
}
