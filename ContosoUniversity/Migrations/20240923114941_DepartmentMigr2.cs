﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentMigr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Budget = table.Column<decimal>(type: "Money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuperImportantString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte>(type: "tinyint", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentID",
                table: "Instructor",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorID",
                table: "Departments",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DepartmentID",
                table: "Course",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DepartmentID",
                table: "Instructor",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DepartmentID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DepartmentID",
                table: "Instructor");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_DepartmentID",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Course");
        }
    }
}
