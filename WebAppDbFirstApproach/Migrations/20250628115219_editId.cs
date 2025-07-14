using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDbFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class editId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblproductimg",
                newName: "ProductImgId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImgId",
                table: "tblproductimg",
                newName: "Id");
        }
    }
}
