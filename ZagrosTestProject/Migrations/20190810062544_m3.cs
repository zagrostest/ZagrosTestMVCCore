using Microsoft.EntityFrameworkCore.Migrations;

namespace ZagrosTestProject.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_GenderTypes_GenderTypeId",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_GenderTypeId",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "GenderTypeId",
                table: "Personnels");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Personnels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_GenderId",
                table: "Personnels",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_GenderTypes_GenderId",
                table: "Personnels",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_GenderTypes_GenderId",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_GenderId",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Personnels");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Personnels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GenderTypeId",
                table: "Personnels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_GenderTypeId",
                table: "Personnels",
                column: "GenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_GenderTypes_GenderTypeId",
                table: "Personnels",
                column: "GenderTypeId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
