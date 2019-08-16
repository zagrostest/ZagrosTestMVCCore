using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZagrosTestProject.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationDegreeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EducationDegreeTitle = table.Column<string>(nullable: true),
                    EducationDegreeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDegreeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderTitle = table.Column<string>(nullable: true),
                    GenderDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaritalStatusTitle = table.Column<string>(nullable: true),
                    MaritalStatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionTitle = table.Column<string>(nullable: true),
                    PositionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_GenderTypes_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_MaritalStatusTypes_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    GenderTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnels_GenderTypes_GenderTypeId",
                        column: x => x.GenderTypeId,
                        principalTable: "GenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnels_MaritalStatusTypes_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_PositionTypes_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EducationId = table.Column<int>(nullable: false),
                    PersonnelId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    EducationDegreeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_EducationDegreeTypes_EducationDegreeTypeId",
                        column: x => x.EducationDegreeTypeId,
                        principalTable: "EducationDegreeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationDegreeTypeId",
                table: "Educations",
                column: "EducationDegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_PersonnelId",
                table: "Educations",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_GenderTypeId",
                table: "Personnels",
                column: "GenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_MaritalStatusId",
                table: "Personnels",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_PositionId",
                table: "Personnels",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GenderId",
                table: "Persons",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MaritalStatusId",
                table: "Persons",
                column: "MaritalStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EducationDegreeTypes");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "GenderTypes");

            migrationBuilder.DropTable(
                name: "MaritalStatusTypes");

            migrationBuilder.DropTable(
                name: "PositionTypes");
        }
    }
}
