using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.DataAccess.Migrations
{
    public partial class Table1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Employees_EmployeeIdId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_LastWorks_Employees_EmployeeIdId",
                table: "LastWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Employees_EmployeeIdId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Vacancies_VacancyIdId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LastWorks",
                table: "LastWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.RenameTable(
                name: "LastWorks",
                newName: "LastWork");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameColumn(
                name: "VacancyIdId",
                table: "Results",
                newName: "VacancyId");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "Results",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_VacancyIdId",
                table: "Results",
                newName: "IX_Results_VacancyId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_EmployeeIdId",
                table: "Results",
                newName: "IX_Results_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "LastWork",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LastWorks_EmployeeIdId",
                table: "LastWork",
                newName: "IX_LastWork_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "Education",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_EmployeeIdId",
                table: "Education",
                newName: "IX_Education_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastWork",
                table: "LastWork",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Employees_EmployeeId",
                table: "Education",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LastWork_Employees_EmployeeId",
                table: "LastWork",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Employees_EmployeeId",
                table: "Results",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Vacancies_VacancyId",
                table: "Results",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Employees_EmployeeId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_LastWork_Employees_EmployeeId",
                table: "LastWork");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Employees_EmployeeId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Vacancies_VacancyId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LastWork",
                table: "LastWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "LastWork",
                newName: "LastWorks");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameColumn(
                name: "VacancyId",
                table: "Results",
                newName: "VacancyIdId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Results",
                newName: "EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_VacancyId",
                table: "Results",
                newName: "IX_Results_VacancyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_EmployeeId",
                table: "Results",
                newName: "IX_Results_EmployeeIdId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LastWorks",
                newName: "EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_LastWork_EmployeeId",
                table: "LastWorks",
                newName: "IX_LastWorks_EmployeeIdId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Educations",
                newName: "EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_EmployeeId",
                table: "Educations",
                newName: "IX_Educations_EmployeeIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastWorks",
                table: "LastWorks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Employees_EmployeeIdId",
                table: "Educations",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LastWorks_Employees_EmployeeIdId",
                table: "LastWorks",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Employees_EmployeeIdId",
                table: "Results",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Vacancies_VacancyIdId",
                table: "Results",
                column: "VacancyIdId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
