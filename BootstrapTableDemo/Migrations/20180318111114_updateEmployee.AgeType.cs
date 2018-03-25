using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BootstrapTableDemo.Migrations
{
    public partial class updateEmployeeAgeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "InfoEmployees",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    DepartmentsName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesList");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "InfoEmployees",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }
    }
}
