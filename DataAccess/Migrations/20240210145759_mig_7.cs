using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImage_Cars_CarId",
                table: "CarImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage");

            migrationBuilder.RenameTable(
                name: "CarImage",
                newName: "CarImages");

            migrationBuilder.RenameIndex(
                name: "IX_CarImage_CarId",
                table: "CarImages",
                newName: "IX_CarImages_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages");

            migrationBuilder.RenameTable(
                name: "CarImages",
                newName: "CarImage");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_CarId",
                table: "CarImage",
                newName: "IX_CarImage_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImage_Cars_CarId",
                table: "CarImage",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
