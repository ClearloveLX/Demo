using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BootstrapTableDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Department = table.Column<int>(unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoEmployee_InfoDepartment",
                        column: x => x.Department,
                        principalTable: "InfoDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoEmployees_Department",
                table: "InfoEmployees",
                column: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoEmployees");

            migrationBuilder.DropTable(
                name: "InfoDepartments");
        }
    }
}
